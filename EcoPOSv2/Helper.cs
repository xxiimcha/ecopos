using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Data;

public class Helper
{
    private const string password = "ABCD";
    private const int iteration = 1024;

    private byte[] salt = Encoding.ASCII.GetBytes("This is My Salt value");


    public string Encrypt(string plaintext)
    {
        Rfc2898DeriveBytes KeyBytes = new Rfc2898DeriveBytes(password, salt, iteration);

        RijndaelManaged alg = new RijndaelManaged();

        alg.Key = KeyBytes.GetBytes(32);
        alg.IV = KeyBytes.GetBytes(16);

        MemoryStream encryptStream = new MemoryStream();

        CryptoStream encryptThis = new CryptoStream(encryptStream, alg.CreateEncryptor(), CryptoStreamMode.Write);

        byte[] data = Encoding.UTF8.GetBytes(plaintext);

        encryptThis.Write(data, 0, data.Length);
        encryptThis.FlushFinalBlock();
        encryptThis.Close();

        return Convert.ToBase64String(encryptStream.ToArray());
    }

    public string Decrypt(string ciphertext)
    {
        Rfc2898DeriveBytes KeyBytes = new Rfc2898DeriveBytes(password, salt, iteration);

        RijndaelManaged alg = new RijndaelManaged();

        alg.Key = KeyBytes.GetBytes(32);
        alg.IV = KeyBytes.GetBytes(16);

        MemoryStream decryptStream = new MemoryStream();

        CryptoStream decryptThis = new CryptoStream(decryptStream, alg.CreateDecryptor(), CryptoStreamMode.Write);

        byte[] data = Convert.FromBase64String(ciphertext);

        decryptThis.Write(data, 0, data.Length);
        decryptThis.Flush();
        decryptThis.Close();

        return Encoding.UTF8.GetString(decryptStream.ToArray());
    }

    public DataSet LoadFromXMLfile(string filename)
    {
        DataSet ds = new DataSet();

        if (System.IO.File.Exists(filename))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ds.GetType());
            FileStream readStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            ds = (DataSet)xmlSerializer.Deserialize(readStream);
            readStream.Close();
        }
        else
            Interaction.MsgBox("file not found! add data and press save button first.", MsgBoxStyle.Exclamation, "");

        return ds;
    }
}
