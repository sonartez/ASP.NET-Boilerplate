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

        $('.delete-note').click(function () {
            var noteId = $(this).attr("data-note-id");
            var rowIid = $(this).attr("data-row-id");
            deleteNote(noteId, rowIid);
        });

        $('.delete-notebook').click(function () {
            var notebookId = $(this).attr("data-notebook-id");
            var notebookName = $(this).attr("data-notebook-name");

            var rowIid = $(this).attr("data-row-id");

            deleteNotebook(notebookId, notebookName, rowIid);
        });

        $('.edit-note').click(function (e) {
            var noteId = $(this).attr("data-note-id");
            
            var editor = $('#ta_' + noteId);
            editor.attr('contenteditable', 'true').focus();

            $('#note_menu_' + noteId).hide();
            $('#note_save_' + noteId).show();
        });

        $('.btn-save-note').click(function (e) {
            console.log(e);
            var noteId = $(this).attr("data-note-id");
            var notebookId = $(this).attr("data-notebook-id");
            var editor = $('#ta_' + noteId);
            editor.attr('contenteditable', 'false');

            $('#note_menu_' + noteId).show();
            $('#note_save_' + noteId).hide();

            _notebookService.updateNote({
                Id: noteId,
                NotebookId: notebookId,
                Content: editor.html()
            }).done(function (res) {
                console.log(res);
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


        function removeRow(rowId) {
            $("#" + rowId).remove();
        }

        function deleteNote(noteId, rowId) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'KworkPractice'), "this note"),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _notebookService.removeNote(noteId)
                            .done(function (res) {

                                if (res) removeRow(rowId);
                                else {
                                    abp.message.error('Delete action unsuccessful', 'Oop! Delete failed');
                                }
                                //refreshUserList();
                            });
                    }
                }
            );
        }

        function deleteNotebook(notebookId, notebookName, rowId) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'KworkPractice'), notebookName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _notebookService.remove(notebookId)
                            .done(function (res) {
                                if (res) removeRow(rowId);
                                else {
                                    abp.message.error('Delete action unsuccess', 'Oop! Delete failed');
                                }
                                //refreshUserList();
                            });
                    }
                }
            );
        }
    });
})();
