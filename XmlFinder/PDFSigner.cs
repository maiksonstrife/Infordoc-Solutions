using System;
using System.Collections.Generic;
using System.Text;


using org.bouncycastle.crypto;
using org.bouncycastle.x509;
using System.Collections;
using org.bouncycastle.pkcs;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.xml.xmp;
using ScanPDF;
using System.Windows.Forms;
using iTextSharp.text;

///
/// <summary>
/// This Library allows you to sign a PDF document using iTextSharp
/// </summary>
/// <author>Alaa-eddine KADDOURI</author>
///
///

namespace iTextSharpSign
{

    
    /// <summary>
    /// This class hold the certificate and extract private key needed for e-signature 
    /// </summary>
    class Cert
    {
        #region Attributes

        private string path = "";
        private string password = "";
        private AsymmetricKeyParameter akp;
        private org.bouncycastle.x509.X509Certificate[] chain;

        #endregion

        #region Accessors
        public org.bouncycastle.x509.X509Certificate[] Chain
        {
            get { return chain; }
        }
        public AsymmetricKeyParameter Akp
        {
            get { return akp; }
        }

        public string Path
        {
            get { return path; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion

        #region Helpers

        private void processCert()
        {
            string alias = null;
            PKCS12Store pk12;

            //First we'll read the certificate file
            pk12 = new PKCS12Store(new FileStream(this.Path, FileMode.Open, FileAccess.Read), this.password.ToCharArray());

            //then Iterate throught certificate entries to find the private key entry
            IEnumerator i = pk12.aliases();
            while (i.MoveNext())
            {
                alias = ((string)i.Current);
                if (pk12.isKeyEntry(alias))
                    break;
            }

            this.akp = pk12.getKey(alias).getKey();
            X509CertificateEntry[] ce = pk12.getCertificateChain(alias);
            this.chain = new org.bouncycastle.x509.X509Certificate[ce.Length];
            for (int k = 0; k < ce.Length; ++k)
                chain[k] = ce[k].getCertificate();

        }
        #endregion

        #region Constructors
        public Cert()
        { }
        public Cert(string cpath)
        {
            this.path = cpath;
            this.processCert();
        }
        public Cert(string cpath, string cpassword)
        {
            this.path = cpath;
            this.Password = cpassword;
            this.processCert();
        }
        #endregion

    }

    /// <summary>
    /// This is a holder class for PDF metadata
    /// </summary>
    class MetaData
    {
        private Hashtable info = new Hashtable();

        public Hashtable Info
        {
            get { return info; }
            set { info = value; }
        }

        public string Author
        {
            get { return (string)info["Author"]; }
            set { info.Add("Author", value); }
        }
        public string Title
        {
            get { return (string)info["Title"]; }
            set { info.Add("Title", value); }
        }
        public string Subject
        {
            get { return (string)info["Subject"]; }
            set { info.Add("Subject", value); }
        }
        public string Keywords
        {
            get { return (string)info["Keywords"]; }
            set { info.Add("Keywords", value); }
        }
        public string Producer
        {
            get { return (string)info["Producer"]; }
            set { info.Add("Producer", value); }
        }

        public string Creator
        {
            get { return (string)info["Creator"]; }
            set { info.Add("Creator", value); }
        }

        public Hashtable getMetaData()
        {
            return this.info;
        }
        public byte[] getStreamedMetaData()
        {
            MemoryStream os = new System.IO.MemoryStream();
            XmpWriter xmp = new XmpWriter(os, this.info);
            xmp.Close();
            return os.ToArray();
        }

    }


    /// <summary>
    /// this is the most important class
    /// it uses iTextSharp library to sign a PDF document
    /// </summary>
    class PDFSigner
    {
        UserSetting m_setting;
        private string inputPDF = "";
        private string outputPDF = "";
        private Cert myCert;
        private MetaData metadata;

        public PDFSigner(string input, string output)
        {
            this.inputPDF = input;
            this.outputPDF = output;
        }

        public PDFSigner(string input, string output, Cert cert)
        {
            this.inputPDF = input;
            this.outputPDF = output;
            this.myCert = cert;
        }
        public PDFSigner(string input, string output, MetaData md)
        {
            this.inputPDF = input;
            this.outputPDF = output;
            this.metadata = md;
        }
        public PDFSigner(string input, string output, Cert cert, MetaData md)
        {
            this.inputPDF = input;
            this.outputPDF = output;
            this.myCert = cert;
            this.metadata = md;
        }

        public void Verify()
        {
        }

        //Settings.ini -> Carrega arquivo Settings.ini
        public void Load_AppSettings()
        {
            try
            {
                m_setting = UserSetting.Load();
                if (m_setting == null)
                    m_setting = new UserSetting();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Impossivel Carregar AppSettings " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Sign(string SigReason, string SigContact, string SigLocation, bool visible)
        {
            Load_AppSettings();

            

            PdfReader reader = new PdfReader(this.inputPDF);
            //Activate MultiSignatures
            PdfStamper st = PdfStamper.CreateSignature(reader, new FileStream(this.outputPDF, FileMode.Create, FileAccess.Write), '\0', null, true);
            //Para desabilititar multi-assinaturas remova este comentario : toda nova assinatura invalidará antigas!
            //PdfStamper st = PdfStamper.CreateSignature(reader, new FileStream(this.outputPDF, FileMode.Create, FileAccess.Write), '\0'); 

            st.MoreInfo = this.metadata.getMetaData();
            st.XmpMetadata = this.metadata.getStreamedMetaData();
            PdfSignatureAppearance sap = st.SignatureAppearance;

            sap.SetCrypto(this.myCert.Akp, this.myCert.Chain, null, PdfSignatureAppearance.SELF_SIGNED);

            sap.Reason = SigReason;
            sap.Contact = SigContact;
            sap.Location = SigLocation;

            Rectangle cropBox = reader.GetCropBox(1);
            Rectangle rectangle;

            float width = 100;
            float height = 50;


            if (m_setting.IsSignTopLeft == true)
            {
                 rectangle = new Rectangle(cropBox.Left, cropBox.GetTop(height), cropBox.GetLeft(width), cropBox.Top);
            }
                else if (m_setting.isSignMiddleTop)
                {
                     rectangle = new Rectangle(cropBox.Right / 2.5f, cropBox.GetTop(height), cropBox.GetRight(width), cropBox.Top);
                }
                else if (m_setting.isSignTopRight)
                {
                     rectangle = new Rectangle(cropBox.GetRight(width), cropBox.GetTop(height), cropBox.Right, cropBox.Top);
                } 
                else if (m_setting.isSignBottomLeft)
                {
                     rectangle = new Rectangle(cropBox.Left, cropBox.Bottom, cropBox.GetLeft(width), cropBox.GetBottom(height));
                }
                else if (m_setting.isSignBottomRight) {
                     rectangle = new Rectangle(cropBox.GetRight(width), cropBox.Bottom, cropBox.Right, cropBox.GetBottom(height));
                }
            else //default is middle top
            {
                 rectangle = new Rectangle(cropBox.Left, cropBox.GetTop(height), cropBox.GetLeft(width), cropBox.Top);
            }


            if (visible)
            {
                sap.SetVisibleSignature(new iTextSharp.text.Rectangle(rectangle), 1, null);
            }

            st.Close();
        }




    }
}




