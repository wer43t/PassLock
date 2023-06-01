using Core;
using Core.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VediGroup.Pages.NotesPages
{
    public class EditFileModel : PageModel
    {
        public void OnGet()
        {
        }

        public FileResult OnGetDownloadFileFromDatabase(int id)
        {
            var bytes = DataAccess.GetDocuments().Where(c => c.id == id).FirstOrDefault().binary_data;

            //Send the File to Download.  
            return File(bytes, "application/octet-stream", DataAccess.GetDocuments().Where(c => c.id == id).FirstOrDefault().name);
        }
    }
}
