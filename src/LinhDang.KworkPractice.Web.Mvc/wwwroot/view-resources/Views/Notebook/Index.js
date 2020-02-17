(function () {
    $(function () {

        var _notebookService = abp.services.app.notebook;
        var _$modal = $('#NotebookCreateModal');
        var _$form = _$modal.find('form');

        var _$modalNote = $('#NoteCreateModal');
        var _$formNote = _$modalNote.find('form');

        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-user').click(function () {
            var userId = $(this).attr("data-user-id");
            var userName = $(this).attr('data-user-name');

            deleteUser(userId, userName);
        });

        $('.edit-user').click(function (e) {
            var userId = $(this).attr("data-user-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Users/EditUserModal?userId=' + userId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }
            var notebook = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js           

            abp.ui.setBusy(_$modal);
            _notebookService.create(notebook).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        _$formNote.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$formNote.valid()) {
                return;
            }
            var note = _$formNote.serializeFormToObject(); //serializeFormToObject is defined in main.js           

            abp.ui.setBusy(_$modal);
            _notebookService.addNote(note).done(function () {
                _$modalNote.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modalNote);
            });
        });

        _$modalNote.on('shown.bs.modal', function () {
            _$modalNote.find('input:not([type=hidden]):first').focus();
        });

        function refreshUserList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteUser(userId, userName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'KworkPractice'), userName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _userService.delete({
                            id: userId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();
