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
                        throw new VersionNotSupportedException(new Version(major, minor), fv);
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

    public class VersionNotSupportedException : System.NotSupportedException
    {
        private Version _Version = null;
        private Version _Required = null;

        public VersionNotSupportedException(Version version, Version required) : this(version, required, "The version " + version.Major.ToString() + "." + version.Minor.ToString() + " is not suppored. The required version is " + required.Major.ToString() + "." + required.Minor.ToString())
        {
        }

        public VersionNotSupportedException(Version version, Version required, string message) : this(version, required, message, null)
        {
        }

        public VersionNotSupportedException(Version version, Version required, string message, System.Exception innerException) : base(message, innerException)
        {
            try
            {
                Version = version;
                Required = required;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Version Version
        {
            get
            {
                return _Version;
            }
            private set
            {
                _Version = value;
            }
        }

        public Version Required
        {
            get
            {
                return _Required;
            }
            private set
            {
                _Required = value;
            }
        }
    }
}
