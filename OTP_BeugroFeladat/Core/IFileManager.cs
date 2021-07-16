using OTP_BeugroFeladata.Common;
using System.Collections.Generic;

namespace OTP_BeugroFeladat.Core
{
    public interface IFileManager
    {
        List<string> GetFolderContent();
        void Upload(FileRequestResponse file);
        FileRequestResponse DownLoad(string fileName);
    }
}
