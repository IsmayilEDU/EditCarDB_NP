using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class Compressor
    {
        public static byte[] Compress(byte[] data)
        {
            using (MemoryStream compressedStream = new MemoryStream())
            {
                using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    gzipStream.Write(data, 0, data.Length);
                }
                return compressedStream.ToArray();
            }
        }

        public static byte[] Decompress(byte[] compressedData)
        {
            using (MemoryStream compressedStream = new MemoryStream(compressedData))
            using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (MemoryStream decompressedStream = new MemoryStream())
            {
                gzipStream.CopyTo(decompressedStream);
                return decompressedStream.ToArray();
            }
        }

    }
}
