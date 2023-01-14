using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.Upload;

public partial class Upload : Module
{
    public Upload()
    {
        Title = "Upload Files";
    }

    public override PartialViewResult OnGet()
    {
        return View(this);
    }
    public override PartialViewResult OnPost()
    {
        /* For file upload to work, the form must have the attribute enctype="multipart/form-data"
         * the PageModel must have the attributes [DisableRequestSizeLimit] [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
         */
        using (Stream stream = Page.Request.Form.Files[0].OpenReadStream())
        {
            var buffer = new byte[stream.Length];
            int readResult = 0;
            int totalRead = 0;
            int iterationCount = 0;
            do
            {
                readResult = stream.Read(buffer, totalRead, (int)stream.Length);
                totalRead += readResult;
                iterationCount++;
            } while (readResult > 0);

            if (totalRead != stream.Length)
            {
                throw new Exception("Error receiving file");
            }
        }

        return View(this);
    }
}
