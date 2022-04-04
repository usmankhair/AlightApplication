using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlightApp.Infrastructure.External.Files
{
    public interface IFileHandlerService
    {
        Task<bool> CreateFile(string content);

    }
}
