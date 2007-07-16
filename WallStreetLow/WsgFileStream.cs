using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class WsgFileStream : System.IO.FileStream
    {
        private System.Security.Cryptography.DES _DES = null;
        private System.Security.Cryptography.CryptoStream _CryptoReadStream = null;
        private System.Security.Cryptography.CryptoStream _CryptoWriteStream = null;
        private bool _UseBaseStream = false;

        public WsgFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share) : base(path, mode, access, share)
        {
            try
            {
                byte[] key = {77, 7, 77, 7, 77, 7, 77, 7};
                byte[] iv = {7, 77, 7, 77, 7, 77, 7, 77};
                DES = new System.Security.Cryptography.DESCryptoServiceProvider();
                if (this.CanRead)
                {
                    CryptoReadStream = new System.Security.Cryptography.CryptoStream(this, DES.CreateDecryptor(key, iv), System.Security.Cryptography.CryptoStreamMode.Read);
                }
                if (this.CanWrite)
                {
                    CryptoWriteStream = new System.Security.Cryptography.CryptoStream(this, DES.CreateEncryptor(key, iv), System.Security.Cryptography.CryptoStreamMode.Write);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private System.Security.Cryptography.DES DES
        {
            get
            {
                return _DES;
            }
            set
            {
                _DES = value;
            }
        }

        private System.Security.Cryptography.CryptoStream CryptoReadStream
        {
            get
            {
                return _CryptoReadStream;
            }
            set
            {
                _CryptoReadStream = value;
            }
        }

        private System.Security.Cryptography.CryptoStream CryptoWriteStream
        {
            get
            {
                return _CryptoWriteStream;
            }
            set
            {
                _CryptoWriteStream = value;
            }
        }

        private bool UseBaseStream
        {
            get
            {
                return _UseBaseStream;
            }
            set
            {
                _UseBaseStream = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (CryptoReadStream != null)
                    {
                        if (!UseBaseStream)
                        {
                            UseBaseStream = true;
                            CryptoReadStream.Dispose();
                            CryptoReadStream = null;
                            UseBaseStream = false;
                        }
                    }
                    if (CryptoWriteStream != null)
                    {
                        if (!UseBaseStream)
                        {
                            UseBaseStream = true;
                            CryptoWriteStream.Dispose();
                            CryptoWriteStream = null;
                            UseBaseStream = false;
                        }
                    }
                    if (DES != null)
                    {
                        DES = null;
                    }
                }
                base.Dispose(disposing);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public override int ReadByte()
        {
            try
            {
                if (UseBaseStream)
                {
                    return base.ReadByte();
                }
                else
                {
                    UseBaseStream = true;
                    int i = CryptoReadStream.ReadByte();
                    UseBaseStream = false;
                    return i;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public override int Read(byte[] array, int offset, int count)
        {
            try
            {
                if (UseBaseStream)
                {
                    return base.Read(array, offset, count);
                }
                else
                {
                    UseBaseStream = true;
                    int i = CryptoReadStream.Read(array, offset, count);
                    UseBaseStream = false;
                    return i;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
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
                if (i > 0)
                {
                    byte[] buffer = new byte[i];
                    if (Read(buffer, 0, i) < i)
                        throw new System.IO.EndOfStreamException();
                    return System.Text.Encoding.ASCII.GetString(buffer);
                }
                return string.Empty;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public override void WriteByte(byte value)
        {
            try
            {
                if (UseBaseStream)
                {
                    base.WriteByte(value);
                }
                else
                {
                    UseBaseStream = true;
                    CryptoWriteStream.WriteByte(value);
                    UseBaseStream = false;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public override void Write(byte[] array, int offset, int count)
        {
            try
            {
                if (UseBaseStream)
                {
                    base.Write(array, offset, count);
                }
                else
                {
                    UseBaseStream = true;
                    CryptoWriteStream.Write(array, offset, count);
                    UseBaseStream = false;
                }
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
                if (i > 0)
                {
                    Write(System.Text.Encoding.ASCII.GetBytes(s), 0, i);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public override void Flush()
        {
            try
            {
                if (UseBaseStream)
                {
                    base.Flush();
                }
                else
                {
                    UseBaseStream = true;
                    CryptoWriteStream.Flush();
                    UseBaseStream = false;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
