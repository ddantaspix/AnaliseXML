using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseXMLNFeCTe
{
    public class Colors
    {

        public static Dictionary<string, Color> Load()
        {
           
            return new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
            {
                { "cteProc", Color.Honeydew },
                { "CTe", Color.LightGreen },
                { "infCte", Color.PaleGreen },
                { "ide", Color.LightYellow },
                { "cUF", Color.LemonChiffon },
                { "cCT", Color.LemonChiffon },
                { "CFOP", Color.LemonChiffon },
                { "natOp", Color.LemonChiffon },
                { "mod", Color.LemonChiffon },
                { "serie", Color.LemonChiffon },
                { "nCT", Color.LemonChiffon },
                { "dhEmi", Color.LemonChiffon },
                { "tpImp", Color.LemonChiffon },
                { "tpEmis", Color.LemonChiffon },
                { "cDV", Color.LemonChiffon },
                { "tpAmb", Color.LemonChiffon },
                { "tpCTe", Color.LemonChiffon },
                { "procEmi", Color.LemonChiffon },
                { "verProc", Color.LemonChiffon },

                { "emit", Color.MistyRose },
                { "rem", Color.LavenderBlush },
                { "dest", Color.SeaShell },
                { "enderEmit", Color.PapayaWhip },
                { "enderReme", Color.Bisque },
                { "enderDest", Color.PeachPuff },

                { "CNPJ", Color.LightCyan },
                { "CPF", Color.LightCyan },
                { "IE", Color.LightCyan },
                { "xNome", Color.Azure },
                { "xLgr", Color.OldLace },
                { "nro", Color.OldLace },
                { "xCpl", Color.OldLace },
                { "xBairro", Color.OldLace },
                { "cMun", Color.OldLace },
                { "xMun", Color.OldLace },
                { "CEP", Color.OldLace },
                { "UF", Color.OldLace },
                { "fone", Color.OldLace },

                { "vPrest", Color.PeachPuff },
                { "vTPrest", Color.Moccasin },
                { "vRec", Color.Moccasin },

                { "imp", Color.MistyRose },
                { "ICMS", Color.LightCoral },
                { "ICMS00", Color.LightSalmon },
                { "CST", Color.Linen },
                { "vBC", Color.Linen },
                { "pICMS", Color.Linen },
                { "vICMS", Color.Linen },
                { "vTotTrib", Color.Linen },

                { "IBSCBS", Color.LightGoldenrodYellow },
                { "cClassTrib", Color.LightGoldenrodYellow },
                { "gIBSCBS", Color.PaleGoldenrod },
                { "gIBSUF", Color.Khaki },
                { "pIBSUF", Color.Khaki },
                { "vIBSUF", Color.Khaki },
                { "gIBSMun", Color.Cornsilk },
                { "pIBSMun", Color.Cornsilk },
                { "vIBSMun", Color.Cornsilk },
                { "vIBS", Color.PaleGoldenrod },
                { "gCBS", Color.Wheat },
                { "pCBS", Color.Wheat },
                { "vCBS", Color.Wheat },
                { "vTotDFe", Color.LightGoldenrodYellow },

                { "infCTeNorm", Color.Honeydew },
                { "infCarga", Color.PaleTurquoise },
                { "vCarga", Color.Azure },
                { "proPred", Color.Azure },
                { "infQ", Color.LightCyan },
                { "cUnid", Color.Azure },
                { "tpMed", Color.Azure },
                { "qCarga", Color.Azure },

                { "infDoc", Color.Lavender },
                { "infNFe", Color.Thistle },
                { "chave", Color.GhostWhite },
                { "dPrev", Color.GhostWhite },

                { "infModal", Color.LightSteelBlue },
                { "rodo", Color.AliceBlue },
                { "RNTRC", Color.AliceBlue },

                { "infCTeSupl", Color.LightGray },
                { "qrCodCTe", Color.Gainsboro },

                { "Signature", Color.WhiteSmoke },
                { "SignedInfo", Color.WhiteSmoke },
                { "CanonicalizationMethod", Color.WhiteSmoke },
                { "SignatureMethod", Color.WhiteSmoke },
                { "Reference", Color.WhiteSmoke },
                { "Transforms", Color.WhiteSmoke },
                { "Transform", Color.WhiteSmoke },
                { "DigestMethod", Color.WhiteSmoke },
                { "DigestValue", Color.WhiteSmoke },
                { "SignatureValue", Color.WhiteSmoke },
                { "KeyInfo", Color.WhiteSmoke },
                { "X509Data", Color.WhiteSmoke },
                { "X509Certificate", Color.WhiteSmoke },

                { "protCTe", Color.LightBlue },
                { "infProt", Color.PowderBlue },
                { "verAplic", Color.AliceBlue },
                { "chCTe", Color.AliceBlue },
                { "dhRecbto", Color.AliceBlue },
                { "nProt", Color.AliceBlue },
                { "digVal", Color.AliceBlue },
                { "cStat", Color.AliceBlue },
                { "xMotivo", Color.AliceBlue }
            };
        }
    }
}

