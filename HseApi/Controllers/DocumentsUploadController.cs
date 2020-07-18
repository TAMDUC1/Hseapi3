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
using Microsoft.Extensions.Configuration;

namespace HseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsUploadController : ControllerBase
    {
        private readonly hse_dev_2019Context _context;
        private readonly IConfiguration _configuration;

        public DocumentsUploadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult PostDocumentsUpload()
        {
            var pathToDb = "";
            var fileName = "";
            try
            {
                string path = _configuration.GetSection("uploadsPath")?.Value;
                string dir = Path.Combine(path + "uploads"); //\\10.1.8.76\c$\inetpub\wwwroot\www\content
                Directory.SetCurrentDirectory(dir);
                // var file = Request.Form.Files[0];
                //   Request.Form
                foreach (IFormFile File in Request.Form.Files)
                {
                    DateTime myDateTime = DateTime.Now;
                    string year = myDateTime.Year.ToString();
                    string month = myDateTime.Month.ToString("00");
                    string date = myDateTime.Day.ToString("00");
                    string[] paths = new string[] { Directory.GetCurrentDirectory(), year, month, date };


                    // var folderName = Path.Combine("Resources", "Images");
                    // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    pathToDb = Path.Combine(year,month,date);
                    var pathToSave = Path.Combine(paths);
                    if (!Directory.Exists(pathToSave))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(pathToSave);
                    }

                    // Directory.GetDirectoryRoot
                    // string dir = @"C:\test";		D:\source\HSE.PVN.VN_V2_2019\content\uploads

                    if (File.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(File.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        //   var dbPath = Path.Combine(folderName, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            File.CopyTo(stream);
                        }

                      //  return Ok(new { fullPath });
                      // 
                    }

                    else
                    {
                        return BadRequest();
                    }
                }
                // return  JsonResult({ });
                return Ok(new { 
                                data = "",
                                module = "hse",
                                workflow ="",
                                model = "hse_audit",
                                model_uuid= "",
                                path  = pathToDb,
                                name = fileName
                                }) ;

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}

