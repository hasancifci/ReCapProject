﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities
{
    public class FileHelper
    {
        static string uploadPath = Environment.CurrentDirectory + @"\wwwroot";
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }

            var newFileName = @"\uploads\"+newGuid(file);
            File.Move(sourcepath, uploadPath + newFileName);
            return newFileName;
        }
        public static IResult Delete(string fileName)
        {
            try
            {
                File.Delete(uploadPath + fileName);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var newFileName = newGuid(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(uploadPath + newFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return newFileName;
        }
        public static string newGuid(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            var newGuid = Guid.NewGuid().ToString() + fileExtension;
            return newGuid;
        }
    }
}
