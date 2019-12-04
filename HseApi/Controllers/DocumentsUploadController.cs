using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HseApi.Models;
using System.Net.Http.Headers;

namespace HseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsUploadController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult PostDocumentsUpload()
        {

            try
            {
                string dir = @"D:\source\HSE.PVN.VN_V2_2019\content\uploads";
                Directory.SetCurrentDirectory(dir);
                // var file = Request.Form.Files[0];
                //   Request.Form
                foreach (IFormFile File in Request.Form.Files)
                {
                    DateTime myDateTime = DateTime.Now;
                    string year = myDateTime.Year.ToString();
                    string month = myDateTime.Month.ToString();
                    string date = myDateTime.Day.ToString();
                    string[] paths = new string[] { Directory.GetCurrentDirectory(), year, month, date };


                    // var folderName = Path.Combine("Resources", "Images");
                    // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var pathToSave = Path.Combine(paths);
                    if (!Directory.Exists(pathToSave))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(pathToSave);
                    }

                    // Directory.GetDirectoryRoot
                    // string dir = @"C:\test";		D:\source\HSE.PVN.VN_V2_2019\content\uploads

                    if (File.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(File.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        //   var dbPath = Path.Combine(folderName, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            File.CopyTo(stream);
                        }

                      //  return Ok(new { fullPath });
                    }

                    else
                    {
                        return BadRequest();
                    }
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}