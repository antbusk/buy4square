/**
 * Echoes the signed message and exits
 */
public void SignMessage(String message)
{
     // #########################################################
     // #             WARNING   WARNING   WARNING               #
     // #########################################################
     // #                                                       #
     // # This file is intended for demonstration purposes      #
     // # only.                                                 #
     // #                                                       #
     // # It is the SOLE responsibility of YOU, the programmer  #
     // # to prevent against unauthorized access to any signing #
     // # functions.                                            #
     // #                                                       #
     // # Organizations that do not protect against un-         #
     // # authorized signing will be black-listed to prevent    #
     // # software piracy.                                      #
     // #                                                       #
     // # -QZ Industries, LLC                                   #
     // #                                                       #
     // #########################################################

    // Sample key.  Replace with one used for CSR generation
    // How to associate a private key with the X509Certificate2 class in .net
    // openssl pkcs12 -export -in private-key.pem -inkey digital-certificate.txt -out private-key.pfx
	var KEY = "private-key.pfx";
	var PASS = "S3cur3P@ssw0rd";

	var cert = new X509Certificate2( KEY, PASS );
	RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PrivateKey;

	byte[] data = new ASCIIEncoding().GetBytes(message);

	byte[] hash = new SHA1Managed().ComputeHash(data);

	Response.ContentType = "text/plain";
	Response.Write(csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1")));  
	Environment.Exit(0)
}
