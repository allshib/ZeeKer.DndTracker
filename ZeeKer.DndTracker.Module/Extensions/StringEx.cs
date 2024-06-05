using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Extensions
{
    public static class StringEx
    {

        public static void OpenAsLink(this string url)
        {
            try
            {
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true 
                });
            }
            catch
            {
                throw new UserFriendlyException("Не удалось открыть ссылку");
            }
        }
    }
}
