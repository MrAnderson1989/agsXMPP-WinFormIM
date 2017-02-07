/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright (c) 2003-2008 by AG-Software 											 *
 * All Rights Reserved.																 *
 * Contact information for AG-Software is available at http://www.ag-software.de	 *
 *																					 *
 * Licence:																			 *
 * The agsXMPP SDK is released under a dual licence									 *
 * agsXMPP can be used under either of two licences									 *
 * 																					 *
 * A commercial licence which is probably the most appropriate for commercial 		 *
 * corporate use and closed source projects. 										 *
 *																					 *
 * The GNU Public License (GPL) is probably most appropriate for inclusion in		 *
 * other open source projects.														 *
 *																					 *
 * See README.html for details.														 *
 *																					 *
 * For general enquiries visit our website at:										 *
 * http://www.ag-software.de														 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;

using agsXMPP.sasl;
using agsXMPP.sasl.Plain;
#if !SL
using agsXMPP.sasl.DigestMD5;
#endif
using agsXMPP.sasl.Anonymous;
using agsXMPP.sasl.XGoogleToken;


namespace agsXMPP.Factory
{
	/// <summary>
	/// SASL factory
	/// </summary>
	public class SaslFactory
	{
		/// <summary>
		/// This Hashtable stores Mapping of mechanism <--> SASL class in agsXMPP
		/// </summary>
		private static Hashtable m_table = new Hashtable();

		static SaslFactory()
		{
			AddMechanism(protocol.sasl.Mechanism.GetMechanismName(protocol.sasl.MechanismType.PLAIN),		    typeof(PlainMechanism));
			AddMechanism(protocol.sasl.Mechanism.GetMechanismName(protocol.sasl.MechanismType.DIGEST_MD5),	    typeof(DigestMD5Mechanism));
            AddMechanism(protocol.sasl.Mechanism.GetMechanismName(protocol.sasl.MechanismType.ANONYMOUS),       typeof(AnonymousMechanism));
            AddMechanism(protocol.sasl.Mechanism.GetMechanismName(protocol.sasl.MechanismType.X_GOOGLE_TOKEN),  typeof(XGoogleTokenMechanism));
		}


		public static Mechanism GetMechanism(string mechanism)
		{
			Type t = (Type) m_table[mechanism];
			if (t != null)
				return (Mechanism) Activator.CreateInstance(t);
			else
				return null;			
		}
		
		/// <summary>
		/// Adds new Element Types to the Hashtable
		/// Use this function to register new SASL mechanisms
		/// </summary>
		/// <param name="mechanism"></param>
		/// <param name="t"></param>
		public static void AddMechanism(string mechanism, System.Type t)
		{
			m_table.Add( mechanism, t);
		}
	}
}
