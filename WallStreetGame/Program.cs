using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OSDevGrp.WallStreetGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                System.Collections.Generic.List<Microsoft.Win32.RegistryKey> rks = new System.Collections.Generic.List<Microsoft.Win32.RegistryKey>();
                try
                {
                    Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(".wsg", false);
                    if (rk == null)
                    {
                        rk = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(".wsg");
                        if (rk != null)
                        {
                            rks.Add(rk);
                            rk.SetValue(null, Application.ProductName.Replace(" ", null), Microsoft.Win32.RegistryValueKind.String);
                            rk.Close();
                            rks.Remove(rk);
                        }
                    }
                    else
                        rk.Close();
                    rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(Application.ProductName.Replace(" ", null), true);
                    if (rk == null)
                        rk = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(Application.ProductName.Replace(" ", null));
                    if (rk != null)
                    {
                        rks.Add(rk);
                        rk.SetValue(null, MainForm.WsgFileInformation, Microsoft.Win32.RegistryValueKind.String);
                        rk = rks[rks.Count - 1].OpenSubKey("DefaultIcon", true);
                        if (rk == null)
                            rk = rks[rks.Count - 1].CreateSubKey("DefaultIcon");
                        if (rk != null)
                        {
                            rks.Add(rk);
                            rk.SetValue(null, Application.ExecutablePath + ",0", Microsoft.Win32.RegistryValueKind.String);
                            rk.Close();
                            rks.Remove(rk);
                        }
                        rk = rks[rks.Count - 1].OpenSubKey("shell", true);
                        if (rk == null)
                            rk = rks[rks.Count - 1].CreateSubKey("shell");
                        if (rk != null)
                        {
                            rks.Add(rk);
                            rk = rks[rks.Count - 1].OpenSubKey("open", true);
                            if (rk == null)
                                rk = rks[rks.Count - 1].CreateSubKey("open");
                            if (rk != null)
                            {
                                rks.Add(rk);
                                rk = rks[rks.Count - 1].OpenSubKey("command", true);
                                if (rk == null)
                                    rk = rks[rks.Count - 1].CreateSubKey("command");
                                if (rk != null)
                                {
                                    rks.Add(rk);
                                    if (Application.ExecutablePath.IndexOf(' ') >= 0)
                                        rk.SetValue(null, '"' + Application.ExecutablePath + "\" %1", Microsoft.Win32.RegistryValueKind.String);
                                    else
                                        rk.SetValue(null, Application.ExecutablePath + " %1", Microsoft.Win32.RegistryValueKind.String);
                                    rk.Close();
                                    rks.Remove(rk);
                                }
                                rk = rks[rks.Count - 1];
                                rk.Close();
                                rks.Remove(rk);
                            }
                            rk = rks[rks.Count - 1];
                            rk.Close();
                            rks.Remove(rk);
                        }
                        rk = rks[rks.Count - 1];                        
                        rk.Close();
                        rks.Remove(rk);
                    }
                }
                catch (System.Security.SecurityException)
                {
                    while (rks.Count > 0)
                    {
                        Microsoft.Win32.RegistryKey rk = rks[rks.Count - 1];
                        rk.Close();
                        rks.Remove(rk);
                    }
                    // The security exception should not be throwed.
                }
                catch (System.Exception ex)
                {
                    while (rks.Count > 0)
                    {
                        Microsoft.Win32.RegistryKey rk = rks[rks.Count - 1];
                        rk.Close();
                        rks.Remove(rk);
                    }
                    throw ex;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(null, ex.Message, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
   }
}