using Microsoft.AspNetCore.Hosting;
using POS.Application.Utility;

namespace POS.Infrastructure.Utility
{
    public class PosUtility : IPosUtility
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PosUtility(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetImageUrl()
        {
            var parentPath = Directory.GetParent(_webHostEnvironment.ContentRootPath)?.FullName;
            return Path.Combine(parentPath, "POS.Infrastructure", "Assets", "Images");
        }
    }
}
