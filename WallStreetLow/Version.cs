using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Version : System.Object, IStoreable
    {
        byte _Major = 0;
        byte _Minor = 0;

        public Version(byte major, byte minor) : base()
        {
            try
            {
                Major = major;
                Minor = minor;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public byte Major
        {
            get
            {
                return _Major;
            }
            private set
            {
                _Major = value;
            }
        }

        public byte Minor
        {
            get
            {
                return _Minor;
            }
            private set
            {
                _Minor = value;
            }
        }

        public void Save(Version fv, WsgFileStream fs)
        {
            try
            {
                if (fv.Major > 0)
                {
                    fs.WriteByte(fv.Major);
                    fs.WriteByte(fv.Minor);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Object Load(Version fv, WsgFileStream fs, System.Object obj)
        {
            try
            {
                if (fv.Major > 0)
                {
                    byte major = (byte) fs.ReadByte();
                    byte minor = (byte) fs.ReadByte();
                    if (major <= 0 || major > fv.Major || (major == fv.Major && minor > fv.Minor))
                        throw new System.NotSupportedException();
                    return new Version(major, minor);
                }
                return new Version(0, 0);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
