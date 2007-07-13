using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class WsgFileStream : System.IO.FileStream
    {
        public WsgFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share) : base(path, mode, access, share)
        {
        }

        public int ReadInt()
        {
            try
            {
                byte[] buffer = new byte[sizeof(Int32)];
                if (Read(buffer, 0, sizeof(Int32)) < sizeof(Int32))
                    throw new System.IO.EndOfStreamException();
                return System.BitConverter.ToInt32(buffer, 0);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string ReadString()
        {
            try
            {
                int i = ReadInt();
                byte[] buffer = new byte[i];
                if (Read(buffer, 0, i) < i)
                    throw new System.IO.EndOfStreamException();
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void WriteInt(int i)
        {
            try
            {
                Write(System.BitConverter.GetBytes(i), 0, sizeof(Int32));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void WriteString(string s)
        {
            try
            {
                int i = System.Text.Encoding.ASCII.GetByteCount(s);
                WriteInt(i);
                Write(System.Text.Encoding.ASCII.GetBytes(s), 0, i);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
