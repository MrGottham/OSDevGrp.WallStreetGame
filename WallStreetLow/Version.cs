using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Version : System.Object, IStoreable
    {
        byte _Major = 0;
        byte _Minor = 0;
        Version _LoadedVersion = null;

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

        public Version LoadedVersion
        {
            get
            {
                return _LoadedVersion;
            }
            private set
            {
                _LoadedVersion = value;
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

        public void Load(Version fv, WsgFileStream fs)
        {
            try
            {
                if (fv.Major > 0)
                {
                    byte major = (byte) fs.ReadByte();
                    byte minor = (byte) fs.ReadByte();
                    if (major > fv.Major || (major == fv.Major && minor > fv.Minor))
                        throw new System.NotSupportedException();
                    if (LoadedVersion != null)
                        LoadedVersion = null;
                    LoadedVersion = new Version(major, minor);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
