using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	partial class TextInfo
	{
		unsafe string ToUpperInternal (string str)
		{
			if (str.Length == 0)
				return String.Empty;

			string tmp = String.FastAllocateString (str.Length);
			fixed (char* source = str, dest = tmp) {

				char* destPtr = (char*)dest;
				char* sourcePtr = (char*)source;

				for (int n = 0; n < str.Length; n++) {
					*destPtr = ToUpper (*sourcePtr);
					sourcePtr++;
					destPtr++;
				}
			}
			return tmp;
		}

		unsafe string ToLowerInternal (string str)
		{
			if (str.Length == 0)
				return String.Empty;

			string tmp = String.FastAllocateString (str.Length);
			fixed (char* source = str, dest = tmp) {

				char* destPtr = (char*)dest;
				char* sourcePtr = (char*)source;

				for (int n = 0; n < str.Length; n++) {
					*destPtr = ToLower (*sourcePtr);
					sourcePtr++;
					destPtr++;
				}
			}
			return tmp;
		}

		char ToUpperInternal (char c)
		{
			if (!m_cultureData.IsInvariantCulture) {
				switch (c) {
				case '\u00b5':
					return '\u039c';
				case '\u0131':
					return '\u0049';
				case '\u017f':
					return '\u0053';
				case '\u01c5':
				case '\u01c8':
				case '\u01cb':
				case '\u01f2':
					return (char) (c - 1);
				case '\u0345':
					return '\u0399';
				case '\u03c2':
					return '\u03a3';
				case '\u03d0':
					return '\u0392';
				case '\u03d1':
					return '\u0398';
				case '\u03d5':
					return '\u03a6';
				case '\u03d6':
					return '\u03a0';
				case '\u03f0':
					return '\u039a';
				case '\u03f1':
					return '\u03a1';
				case '\u03f5':
					return '\u0395';
				case '\u1e9b':
					return '\u1e60';
				case '\u1fbe':
					return '\u0399';
				}

				if (!IsAsciiCasingSameAsInvariant) {
					if (c == '\u0069')
						return '\u0130';

					if (IsAscii (c))
						return ToUpperAsciiInvariant (c);
				}
			}

			if (c >= '\u00e0' && c <= '\u0586')
				return TextInfoToUpperData.range_00e0_0586 [c - '\u00e0'];
			if (c >= '\u1e01' && c <= '\u1ff3')
				return TextInfoToUpperData.range_1e01_1ff3 [c - '\u1e01'];
			if (c >= '\u2170' && c <= '\u2184')
				return TextInfoToUpperData.range_2170_2184 [c - '\u2170'];
			if (c >= '\u24d0' && c <= '\u24e9')
				return TextInfoToUpperData.range_24d0_24e9 [c - '\u24d0'];
			if (c >= '\u2c30' && c <= '\u2ce3')
				return TextInfoToUpperData.range_2c30_2ce3 [c - '\u2c30'];
			if (c >= '\u2d00' && c <= '\u2d25')
				return TextInfoToUpperData.range_2d00_2d25 [c - '\u2d00'];
			if (c >= '\ua641' && c <= '\ua697')
				return TextInfoToUpperData.range_a641_a697 [c - '\ua641'];
			if (c >= '\ua723' && c <= '\ua78c')
				return TextInfoToUpperData.range_a723_a78c [c - '\ua723'];

			// FF41 - FF5A range maps to FF21 - FF3A
			if ('\uff41' <= c && c <= '\uff5a')
				return (char) (c - '\u0020');

			// Individual ones not close enough to any range
			switch (c) {
			case '\u1d79':
				return '\ua77d';
			case '\u1d7d':
				return '\u2c63';
			case '\u214e':
				return '\u2132';
			}

			return c;
		}		

		char ToLowerInternal (char c)
		{
			if (!m_cultureData.IsInvariantCulture) {
				switch (c) {
				case '\u0130':
					return '\u0069';
				case '\u01c5':
				case '\u01c8':
				case '\u01cb':
				case '\u01f2':
					return (char) (c + 1);
				case '\u03d2':
					return '\u03c5';
				case '\u03d3':
					return '\u03cd';
				case '\u03d4':
					return '\u03cb';
				case '\u03f4':
					return '\u03b8';
				case '\u1e9e':
					return '\u00df';
				case '\u2126':
					return '\u03c9';
				case '\u212a':
					return '\u006b';
				case '\u212b':
					return '\u00e5';
				}

				if (!IsAsciiCasingSameAsInvariant) {
					if (c == '\u0049')
						return '\u0131';

					if (IsAscii (c))
						return ToLowerAsciiInvariant (c);
				}
			}

			if (c >= '\u00c0' && c <= '\u0556')
				return TextInfoToLowerData.range_00c0_0556 [c - '\u00c0'];
			if (c >= '\u10a0' && c <= '\u10c5')
				return TextInfoToLowerData.range_10a0_10c5 [c - '\u10a0'];
			if (c >= '\u1e00' && c <= '\u1ffc')
				return TextInfoToLowerData.range_1e00_1ffc [c - '\u1e00'];
			if (c >= '\u2160' && c <= '\u216f')
				return TextInfoToLowerData.range_2160_216f [c - '\u2160'];
			if (c >= '\u24b6' && c <= '\u24cf')
				return TextInfoToLowerData.range_24b6_24cf [c - '\u24b6'];
			if (c >= '\u2c00' && c <= '\u2c2e')
				return TextInfoToLowerData.range_2c00_2c2e [c - '\u2c00'];
			if (c >= '\u2c60' && c <= '\u2ce2')
				return TextInfoToLowerData.range_2c60_2ce2 [c - '\u2c60'];
			if (c >= '\ua640' && c <= '\ua696')
				return TextInfoToLowerData.range_a640_a696 [c - '\ua640'];
			if (c >= '\ua722' && c <= '\ua78b')
				return TextInfoToLowerData.range_a722_a78b [c - '\ua722'];

			// FF21 - FF3A range maps to FF41 - FF5A
			if ('\uff21' <= c && c <= '\uff3a')
				return (char) (c + '\u0020');

			// Individual ones not close enough to any range
			switch (c) {
			case '\u2132':
				return '\u214e';
			case '\u2183':
				return '\u2184';
			}

			return c;
		}

		static unsafe int InternalCompareStringOrdinalIgnoreCase (String strA, int indexA, String strB, int indexB, int lenA, int lenB)
		{
			if (strA == null) {
				return strB == null ? 0 : -1;
			}
			if (strB == null) {
				return 1;
			}
			int lengthA = Math.Min (lenA, strA.Length - indexA);
			int lengthB = Math.Min (lenB, strB.Length - indexB);

			if (lengthA == lengthB && Object.ReferenceEquals (strA, strB))
				return 0;

			fixed (char* aptr = strA, bptr = strB) {
				char* ap = aptr + indexA;
				char* end = ap + Math.Min (lengthA, lengthB);
				char* bp = bptr + indexB;
				while (ap < end) {
					if (*ap != *bp) {
						char c1 = Char.ToUpperInvariant (*ap);
						char c2 = Char.ToUpperInvariant (*bp);
						if (c1 != c2)
							return c1 - c2;
					}
					ap++;
					bp++;
				}
				return lengthA - lengthB;
			}
		}

		private unsafe string ToLowerAsciiInvariant(string s)
		{
			if (s.Length == 0)
			{
				return string.Empty;
			}
			
			fixed (char* pSource = s)
			{
				int i = 0;
				while (i < s.Length)
				{
					if ((uint)(pSource[i] - 'A') <= (uint)('Z' - 'A'))
					{
						break;
					}
					i++;
				}
				
				if (i >= s.Length)
				{
					return s;
				}

				string result = string.FastAllocateString(s.Length);
				fixed (char* pResult = result)
				{
					for (int j = 0; j < i; j++)
					{
						pResult[j] = pSource[j];
					}
					
					pResult[i] = (char)(pSource[i] | 0x20);
					i++;

					while (i < s.Length)
					{
						pResult[i] = ToLowerAsciiInvariant(pSource[i]);
						i++;
					}
				}

				return result;
			}
		}

		internal void ToLowerAsciiInvariant(ReadOnlySpan<char> source, Span<char> destination)
		{
			for (int i = 0; i < source.Length; i++)
			{
				destination[i] = ToLowerAsciiInvariant(source[i]);
			}
		}

		private unsafe string ToUpperAsciiInvariant(string s)
		{
			if (s.Length == 0)
			{
				return string.Empty;
			}
			
			fixed (char* pSource = s)
			{
				int i = 0;
				while (i < s.Length)
				{
					if ((uint)(pSource[i] - 'a') <= (uint)('z' - 'a'))
					{
						break;
					}
					i++;
				}
				
				if (i >= s.Length)
				{
					return s;
				}

				string result = string.FastAllocateString(s.Length);
				fixed (char* pResult = result)
				{
					for (int j = 0; j < i; j++)
					{
						pResult[j] = pSource[j];
					}
					
					pResult[i] = (char)(pSource[i] & ~0x20);
					i++;

					while (i < s.Length)
					{
						pResult[i] = ToUpperAsciiInvariant(pSource[i]);
						i++;
					}
				}

				return result;
			}
		}

		internal void ToUpperAsciiInvariant(ReadOnlySpan<char> source, Span<char> destination)
		{
			for (int i = 0; i < source.Length; i++)
			{
				destination[i] = ToUpperAsciiInvariant(source[i]);
			}
		}

		internal unsafe void ChangeCase(ReadOnlySpan<char> source, Span<char> destination, bool toUpper)
		{
			if (source.IsEmpty)
			{
				return;
			}

			fixed (char* pSource = &MemoryMarshal.GetReference(source))
			fixed (char* pResult = &MemoryMarshal.GetReference(destination))
			{
				if (IsAsciiCasingSameAsInvariant)
				{
					int length = 0;
					char* a = pSource, b = pResult;
					if (toUpper)
					{
						while (length < source.Length && *a < 0x80)
						{
							*b++ = ToUpperAsciiInvariant(*a++);
							length++;
						}
					}
					else
					{
						while (length < source.Length && *a < 0x80)
						{
							*b++ = ToLowerAsciiInvariant(*a++);
							length++;
						}
					}

					if (length != source.Length)
					{
						//ChangeCase(a, source.Length - length, b, destination.Length - length, toUpper);
						throw new NotImplementedException ();
					}
				}
				else
				{
					//ChangeCase(pSource, source.Length, pResult, destination.Length, toUpper);
					throw new NotImplementedException ();
				}
			}
		}
	}

	static class TextInfoToUpperData
	{
		public static readonly char[] range_00e0_0586 = new char [] { '\u00c0','\u00c1','\u00c2','\u00c3','\u00c4','\u00c5','\u00c6','\u00c7','\u00c8','\u00c9','\u00ca','\u00cb','\u00cc','\u00cd','\u00ce','\u00cf','\u00d0','\u00d1','\u00d2','\u00d3','\u00d4','\u00d5','\u00d6','\u00f7','\u00d8','\u00d9','\u00da','\u00db','\u00dc','\u00dd','\u00de','\u0178','\u0100','\u0100','\u0102','\u0102','\u0104','\u0104','\u0106','\u0106','\u0108','\u0108','\u010a','\u010a','\u010c','\u010c','\u010e','\u010e','\u0110','\u0110','\u0112','\u0112','\u0114','\u0114','\u0116','\u0116','\u0118','\u0118','\u011a','\u011a','\u011c','\u011c','\u011e','\u011e','\u0120','\u0120','\u0122','\u0122','\u0124','\u0124','\u0126','\u0126','\u0128','\u0128','\u012a','\u012a','\u012c','\u012c','\u012e','\u012e','\u0130','\u0131','\u0132','\u0132','\u0134','\u0134','\u0136','\u0136','\u0138','\u0139','\u0139','\u013b','\u013b','\u013d','\u013d','\u013f','\u013f','\u0141','\u0141','\u0143','\u0143','\u0145','\u0145','\u0147','\u0147','\u0149','\u014a','\u014a','\u014c','\u014c','\u014e','\u014e','\u0150','\u0150','\u0152','\u0152','\u0154','\u0154','\u0156','\u0156','\u0158','\u0158','\u015a','\u015a','\u015c','\u015c','\u015e','\u015e','\u0160','\u0160','\u0162','\u0162','\u0164','\u0164','\u0166','\u0166','\u0168','\u0168','\u016a','\u016a','\u016c','\u016c','\u016e','\u016e','\u0170','\u0170','\u0172','\u0172','\u0174','\u0174','\u0176','\u0176','\u0178','\u0179','\u0179','\u017b','\u017b','\u017d','\u017d','\u017f','\u0243','\u0181','\u0182','\u0182','\u0184','\u0184','\u0186','\u0187','\u0187','\u0189','\u018a','\u018b','\u018b','\u018d','\u018e','\u018f','\u0190','\u0191','\u0191','\u0193','\u0194','\u01f6','\u0196','\u0197','\u0198','\u0198','\u023d','\u019b','\u019c','\u019d','\u0220','\u019f','\u01a0','\u01a0','\u01a2','\u01a2','\u01a4','\u01a4','\u01a6','\u01a7','\u01a7','\u01a9','\u01aa','\u01ab','\u01ac','\u01ac','\u01ae','\u01af','\u01af','\u01b1','\u01b2','\u01b3','\u01b3','\u01b5','\u01b5','\u01b7','\u01b8','\u01b8','\u01ba','\u01bb','\u01bc','\u01bc','\u01be','\u01f7','\u01c0','\u01c1','\u01c2','\u01c3','\u01c4','\u01c5','\u01c4','\u01c7','\u01c8','\u01c7','\u01ca','\u01cb','\u01ca','\u01cd','\u01cd','\u01cf','\u01cf','\u01d1','\u01d1','\u01d3','\u01d3','\u01d5','\u01d5','\u01d7','\u01d7','\u01d9','\u01d9','\u01db','\u01db','\u018e','\u01de','\u01de','\u01e0','\u01e0','\u01e2','\u01e2','\u01e4','\u01e4','\u01e6','\u01e6','\u01e8','\u01e8','\u01ea','\u01ea','\u01ec','\u01ec','\u01ee','\u01ee','\u01f0','\u01f1','\u01f2','\u01f1','\u01f4','\u01f4','\u01f6','\u01f7','\u01f8','\u01f8','\u01fa','\u01fa','\u01fc','\u01fc','\u01fe','\u01fe','\u0200','\u0200','\u0202','\u0202','\u0204','\u0204','\u0206','\u0206','\u0208','\u0208','\u020a','\u020a','\u020c','\u020c','\u020e','\u020e','\u0210','\u0210','\u0212','\u0212','\u0214','\u0214','\u0216','\u0216','\u0218','\u0218','\u021a','\u021a','\u021c','\u021c','\u021e','\u021e','\u0220','\u0221','\u0222','\u0222','\u0224','\u0224','\u0226','\u0226','\u0228','\u0228','\u022a','\u022a','\u022c','\u022c','\u022e','\u022e','\u0230','\u0230','\u0232','\u0232','\u0234','\u0235','\u0236','\u0237','\u0238','\u0239','\u023a','\u023b','\u023b','\u023d','\u023e','\u023f','\u0240','\u0241','\u0241','\u0243','\u0244','\u0245','\u0246','\u0246','\u0248','\u0248','\u024a','\u024a','\u024c','\u024c','\u024e','\u024e','\u2c6f','\u2c6d','\u0252','\u0181','\u0186','\u0255','\u0189','\u018a','\u0258','\u018f','\u025a','\u0190','\u025c','\u025d','\u025e','\u025f','\u0193','\u0261','\u0262','\u0194','\u0264','\u0265','\u0266','\u0267','\u0197','\u0196','\u026a','\u2c62','\u026c','\u026d','\u026e','\u019c','\u0270','\u2c6e','\u019d','\u0273','\u0274','\u019f','\u0276','\u0277','\u0278','\u0279','\u027a','\u027b','\u027c','\u2c64','\u027e','\u027f','\u01a6','\u0281','\u0282','\u01a9','\u0284','\u0285','\u0286','\u0287','\u01ae','\u0244','\u01b1','\u01b2','\u0245','\u028d','\u028e','\u028f','\u0290','\u0291','\u01b7','\u0293','\u0294','\u0295','\u0296','\u0297','\u0298','\u0299','\u029a','\u029b','\u029c','\u029d','\u029e','\u029f','\u02a0','\u02a1','\u02a2','\u02a3','\u02a4','\u02a5','\u02a6','\u02a7','\u02a8','\u02a9','\u02aa','\u02ab','\u02ac','\u02ad','\u02ae','\u02af','\u02b0','\u02b1','\u02b2','\u02b3','\u02b4','\u02b5','\u02b6','\u02b7','\u02b8','\u02b9','\u02ba','\u02bb','\u02bc','\u02bd','\u02be','\u02bf','\u02c0','\u02c1','\u02c2','\u02c3','\u02c4','\u02c5','\u02c6','\u02c7','\u02c8','\u02c9','\u02ca','\u02cb','\u02cc','\u02cd','\u02ce','\u02cf','\u02d0','\u02d1','\u02d2','\u02d3','\u02d4','\u02d5','\u02d6','\u02d7','\u02d8','\u02d9','\u02da','\u02db','\u02dc','\u02dd','\u02de','\u02df','\u02e0','\u02e1','\u02e2','\u02e3','\u02e4','\u02e5','\u02e6','\u02e7','\u02e8','\u02e9','\u02ea','\u02eb','\u02ec','\u02ed','\u02ee','\u02ef','\u02f0','\u02f1','\u02f2','\u02f3','\u02f4','\u02f5','\u02f6','\u02f7','\u02f8','\u02f9','\u02fa','\u02fb','\u02fc','\u02fd','\u02fe','\u02ff','\u0300','\u0301','\u0302','\u0303','\u0304','\u0305','\u0306','\u0307','\u0308','\u0309','\u030a','\u030b','\u030c','\u030d','\u030e','\u030f','\u0310','\u0311','\u0312','\u0313','\u0314','\u0315','\u0316','\u0317','\u0318','\u0319','\u031a','\u031b','\u031c','\u031d','\u031e','\u031f','\u0320','\u0321','\u0322','\u0323','\u0324','\u0325','\u0326','\u0327','\u0328','\u0329','\u032a','\u032b','\u032c','\u032d','\u032e','\u032f','\u0330','\u0331','\u0332','\u0333','\u0334','\u0335','\u0336','\u0337','\u0338','\u0339','\u033a','\u033b','\u033c','\u033d','\u033e','\u033f','\u0340','\u0341','\u0342','\u0343','\u0344','\u0345','\u0346','\u0347','\u0348','\u0349','\u034a','\u034b','\u034c','\u034d','\u034e','\u034f','\u0350','\u0351','\u0352','\u0353','\u0354','\u0355','\u0356','\u0357','\u0358','\u0359','\u035a','\u035b','\u035c','\u035d','\u035e','\u035f','\u0360','\u0361','\u0362','\u0363','\u0364','\u0365','\u0366','\u0367','\u0368','\u0369','\u036a','\u036b','\u036c','\u036d','\u036e','\u036f','\u0370','\u0370','\u0372','\u0372','\u0374','\u0375','\u0376','\u0376','\u0378','\u0379','\u037a','\u03fd','\u03fe','\u03ff','\u037e','\u037f','\u0380','\u0381','\u0382','\u0383','\u0384','\u0385','\u0386','\u0387','\u0388','\u0389','\u038a','\u038b','\u038c','\u038d','\u038e','\u038f','\u0390','\u0391','\u0392','\u0393','\u0394','\u0395','\u0396','\u0397','\u0398','\u0399','\u039a','\u039b','\u039c','\u039d','\u039e','\u039f','\u03a0','\u03a1','\u03a2','\u03a3','\u03a4','\u03a5','\u03a6','\u03a7','\u03a8','\u03a9','\u03aa','\u03ab','\u0386','\u0388','\u0389','\u038a','\u03b0','\u0391','\u0392','\u0393','\u0394','\u0395','\u0396','\u0397','\u0398','\u0399','\u039a','\u039b','\u039c','\u039d','\u039e','\u039f','\u03a0','\u03a1','\u03c2','\u03a3','\u03a4','\u03a5','\u03a6','\u03a7','\u03a8','\u03a9','\u03aa','\u03ab','\u038c','\u038e','\u038f','\u03cf','\u03d0','\u03d1','\u03d2','\u03d3','\u03d4','\u03d5','\u03d6','\u03cf','\u03d8','\u03d8','\u03da','\u03da','\u03dc','\u03dc','\u03de','\u03de','\u03e0','\u03e0','\u03e2','\u03e2','\u03e4','\u03e4','\u03e6','\u03e6','\u03e8','\u03e8','\u03ea','\u03ea','\u03ec','\u03ec','\u03ee','\u03ee','\u03f0','\u03f1','\u03f9','\u03f3','\u03f4','\u03f5','\u03f6','\u03f7','\u03f7','\u03f9','\u03fa','\u03fa','\u03fc','\u03fd','\u03fe','\u03ff','\u0400','\u0401','\u0402','\u0403','\u0404','\u0405','\u0406','\u0407','\u0408','\u0409','\u040a','\u040b','\u040c','\u040d','\u040e','\u040f','\u0410','\u0411','\u0412','\u0413','\u0414','\u0415','\u0416','\u0417','\u0418','\u0419','\u041a','\u041b','\u041c','\u041d','\u041e','\u041f','\u0420','\u0421','\u0422','\u0423','\u0424','\u0425','\u0426','\u0427','\u0428','\u0429','\u042a','\u042b','\u042c','\u042d','\u042e','\u042f','\u0410','\u0411','\u0412','\u0413','\u0414','\u0415','\u0416','\u0417','\u0418','\u0419','\u041a','\u041b','\u041c','\u041d','\u041e','\u041f','\u0420','\u0421','\u0422','\u0423','\u0424','\u0425','\u0426','\u0427','\u0428','\u0429','\u042a','\u042b','\u042c','\u042d','\u042e','\u042f','\u0400','\u0401','\u0402','\u0403','\u0404','\u0405','\u0406','\u0407','\u0408','\u0409','\u040a','\u040b','\u040c','\u040d','\u040e','\u040f','\u0460','\u0460','\u0462','\u0462','\u0464','\u0464','\u0466','\u0466','\u0468','\u0468','\u046a','\u046a','\u046c','\u046c','\u046e','\u046e','\u0470','\u0470','\u0472','\u0472','\u0474','\u0474','\u0476','\u0476','\u0478','\u0478','\u047a','\u047a','\u047c','\u047c','\u047e','\u047e','\u0480','\u0480','\u0482','\u0483','\u0484','\u0485','\u0486','\u0487','\u0488','\u0489','\u048a','\u048a','\u048c','\u048c','\u048e','\u048e','\u0490','\u0490','\u0492','\u0492','\u0494','\u0494','\u0496','\u0496','\u0498','\u0498','\u049a','\u049a','\u049c','\u049c','\u049e','\u049e','\u04a0','\u04a0','\u04a2','\u04a2','\u04a4','\u04a4','\u04a6','\u04a6','\u04a8','\u04a8','\u04aa','\u04aa','\u04ac','\u04ac','\u04ae','\u04ae','\u04b0','\u04b0','\u04b2','\u04b2','\u04b4','\u04b4','\u04b6','\u04b6','\u04b8','\u04b8','\u04ba','\u04ba','\u04bc','\u04bc','\u04be','\u04be','\u04c0','\u04c1','\u04c1','\u04c3','\u04c3','\u04c5','\u04c5','\u04c7','\u04c7','\u04c9','\u04c9','\u04cb','\u04cb','\u04cd','\u04cd','\u04c0','\u04d0','\u04d0','\u04d2','\u04d2','\u04d4','\u04d4','\u04d6','\u04d6','\u04d8','\u04d8','\u04da','\u04da','\u04dc','\u04dc','\u04de','\u04de','\u04e0','\u04e0','\u04e2','\u04e2','\u04e4','\u04e4','\u04e6','\u04e6','\u04e8','\u04e8','\u04ea','\u04ea','\u04ec','\u04ec','\u04ee','\u04ee','\u04f0','\u04f0','\u04f2','\u04f2','\u04f4','\u04f4','\u04f6','\u04f6','\u04f8','\u04f8','\u04fa','\u04fa','\u04fc','\u04fc','\u04fe','\u04fe','\u0500','\u0500','\u0502','\u0502','\u0504','\u0504','\u0506','\u0506','\u0508','\u0508','\u050a','\u050a','\u050c','\u050c','\u050e','\u050e','\u0510','\u0510','\u0512','\u0512','\u0514','\u0514','\u0516','\u0516','\u0518','\u0518','\u051a','\u051a','\u051c','\u051c','\u051e','\u051e','\u0520','\u0520','\u0522','\u0522','\u0524','\u0525','\u0526','\u0527','\u0528','\u0529','\u052a','\u052b','\u052c','\u052d','\u052e','\u052f','\u0530','\u0531','\u0532','\u0533','\u0534','\u0535','\u0536','\u0537','\u0538','\u0539','\u053a','\u053b','\u053c','\u053d','\u053e','\u053f','\u0540','\u0541','\u0542','\u0543','\u0544','\u0545','\u0546','\u0547','\u0548','\u0549','\u054a','\u054b','\u054c','\u054d','\u054e','\u054f','\u0550','\u0551','\u0552','\u0553','\u0554','\u0555','\u0556','\u0557','\u0558','\u0559','\u055a','\u055b','\u055c','\u055d','\u055e','\u055f','\u0560','\u0531','\u0532','\u0533','\u0534','\u0535','\u0536','\u0537','\u0538','\u0539','\u053a','\u053b','\u053c','\u053d','\u053e','\u053f','\u0540','\u0541','\u0542','\u0543','\u0544','\u0545','\u0546','\u0547','\u0548','\u0549','\u054a','\u054b','\u054c','\u054d','\u054e','\u054f','\u0550','\u0551','\u0552','\u0553','\u0554','\u0555','\u0556' };
		public static readonly char[] range_1e01_1ff3 = new char [] { '\u1e00','\u1e02','\u1e02','\u1e04','\u1e04','\u1e06','\u1e06','\u1e08','\u1e08','\u1e0a','\u1e0a','\u1e0c','\u1e0c','\u1e0e','\u1e0e','\u1e10','\u1e10','\u1e12','\u1e12','\u1e14','\u1e14','\u1e16','\u1e16','\u1e18','\u1e18','\u1e1a','\u1e1a','\u1e1c','\u1e1c','\u1e1e','\u1e1e','\u1e20','\u1e20','\u1e22','\u1e22','\u1e24','\u1e24','\u1e26','\u1e26','\u1e28','\u1e28','\u1e2a','\u1e2a','\u1e2c','\u1e2c','\u1e2e','\u1e2e','\u1e30','\u1e30','\u1e32','\u1e32','\u1e34','\u1e34','\u1e36','\u1e36','\u1e38','\u1e38','\u1e3a','\u1e3a','\u1e3c','\u1e3c','\u1e3e','\u1e3e','\u1e40','\u1e40','\u1e42','\u1e42','\u1e44','\u1e44','\u1e46','\u1e46','\u1e48','\u1e48','\u1e4a','\u1e4a','\u1e4c','\u1e4c','\u1e4e','\u1e4e','\u1e50','\u1e50','\u1e52','\u1e52','\u1e54','\u1e54','\u1e56','\u1e56','\u1e58','\u1e58','\u1e5a','\u1e5a','\u1e5c','\u1e5c','\u1e5e','\u1e5e','\u1e60','\u1e60','\u1e62','\u1e62','\u1e64','\u1e64','\u1e66','\u1e66','\u1e68','\u1e68','\u1e6a','\u1e6a','\u1e6c','\u1e6c','\u1e6e','\u1e6e','\u1e70','\u1e70','\u1e72','\u1e72','\u1e74','\u1e74','\u1e76','\u1e76','\u1e78','\u1e78','\u1e7a','\u1e7a','\u1e7c','\u1e7c','\u1e7e','\u1e7e','\u1e80','\u1e80','\u1e82','\u1e82','\u1e84','\u1e84','\u1e86','\u1e86','\u1e88','\u1e88','\u1e8a','\u1e8a','\u1e8c','\u1e8c','\u1e8e','\u1e8e','\u1e90','\u1e90','\u1e92','\u1e92','\u1e94','\u1e94','\u1e96','\u1e97','\u1e98','\u1e99','\u1e9a','\u1e9b','\u1e9c','\u1e9d','\u1e9e','\u1e9f','\u1ea0','\u1ea0','\u1ea2','\u1ea2','\u1ea4','\u1ea4','\u1ea6','\u1ea6','\u1ea8','\u1ea8','\u1eaa','\u1eaa','\u1eac','\u1eac','\u1eae','\u1eae','\u1eb0','\u1eb0','\u1eb2','\u1eb2','\u1eb4','\u1eb4','\u1eb6','\u1eb6','\u1eb8','\u1eb8','\u1eba','\u1eba','\u1ebc','\u1ebc','\u1ebe','\u1ebe','\u1ec0','\u1ec0','\u1ec2','\u1ec2','\u1ec4','\u1ec4','\u1ec6','\u1ec6','\u1ec8','\u1ec8','\u1eca','\u1eca','\u1ecc','\u1ecc','\u1ece','\u1ece','\u1ed0','\u1ed0','\u1ed2','\u1ed2','\u1ed4','\u1ed4','\u1ed6','\u1ed6','\u1ed8','\u1ed8','\u1eda','\u1eda','\u1edc','\u1edc','\u1ede','\u1ede','\u1ee0','\u1ee0','\u1ee2','\u1ee2','\u1ee4','\u1ee4','\u1ee6','\u1ee6','\u1ee8','\u1ee8','\u1eea','\u1eea','\u1eec','\u1eec','\u1eee','\u1eee','\u1ef0','\u1ef0','\u1ef2','\u1ef2','\u1ef4','\u1ef4','\u1ef6','\u1ef6','\u1ef8','\u1ef8','\u1efa','\u1efa','\u1efc','\u1efc','\u1efe','\u1efe','\u1f08','\u1f09','\u1f0a','\u1f0b','\u1f0c','\u1f0d','\u1f0e','\u1f0f','\u1f08','\u1f09','\u1f0a','\u1f0b','\u1f0c','\u1f0d','\u1f0e','\u1f0f','\u1f18','\u1f19','\u1f1a','\u1f1b','\u1f1c','\u1f1d','\u1f16','\u1f17','\u1f18','\u1f19','\u1f1a','\u1f1b','\u1f1c','\u1f1d','\u1f1e','\u1f1f','\u1f28','\u1f29','\u1f2a','\u1f2b','\u1f2c','\u1f2d','\u1f2e','\u1f2f','\u1f28','\u1f29','\u1f2a','\u1f2b','\u1f2c','\u1f2d','\u1f2e','\u1f2f','\u1f38','\u1f39','\u1f3a','\u1f3b','\u1f3c','\u1f3d','\u1f3e','\u1f3f','\u1f38','\u1f39','\u1f3a','\u1f3b','\u1f3c','\u1f3d','\u1f3e','\u1f3f','\u1f48','\u1f49','\u1f4a','\u1f4b','\u1f4c','\u1f4d','\u1f46','\u1f47','\u1f48','\u1f49','\u1f4a','\u1f4b','\u1f4c','\u1f4d','\u1f4e','\u1f4f','\u1f50','\u1f59','\u1f52','\u1f5b','\u1f54','\u1f5d','\u1f56','\u1f5f','\u1f58','\u1f59','\u1f5a','\u1f5b','\u1f5c','\u1f5d','\u1f5e','\u1f5f','\u1f68','\u1f69','\u1f6a','\u1f6b','\u1f6c','\u1f6d','\u1f6e','\u1f6f','\u1f68','\u1f69','\u1f6a','\u1f6b','\u1f6c','\u1f6d','\u1f6e','\u1f6f','\u1fba','\u1fbb','\u1fc8','\u1fc9','\u1fca','\u1fcb','\u1fda','\u1fdb','\u1ff8','\u1ff9','\u1fea','\u1feb','\u1ffa','\u1ffb','\u1f7e','\u1f7f','\u1f88','\u1f89','\u1f8a','\u1f8b','\u1f8c','\u1f8d','\u1f8e','\u1f8f','\u1f88','\u1f89','\u1f8a','\u1f8b','\u1f8c','\u1f8d','\u1f8e','\u1f8f','\u1f98','\u1f99','\u1f9a','\u1f9b','\u1f9c','\u1f9d','\u1f9e','\u1f9f','\u1f98','\u1f99','\u1f9a','\u1f9b','\u1f9c','\u1f9d','\u1f9e','\u1f9f','\u1fa8','\u1fa9','\u1faa','\u1fab','\u1fac','\u1fad','\u1fae','\u1faf','\u1fa8','\u1fa9','\u1faa','\u1fab','\u1fac','\u1fad','\u1fae','\u1faf','\u1fb8','\u1fb9','\u1fb2','\u1fbc','\u1fb4','\u1fb5','\u1fb6','\u1fb7','\u1fb8','\u1fb9','\u1fba','\u1fbb','\u1fbc','\u1fbd','\u1fbe','\u1fbf','\u1fc0','\u1fc1','\u1fc2','\u1fcc','\u1fc4','\u1fc5','\u1fc6','\u1fc7','\u1fc8','\u1fc9','\u1fca','\u1fcb','\u1fcc','\u1fcd','\u1fce','\u1fcf','\u1fd8','\u1fd9','\u1fd2','\u1fd3','\u1fd4','\u1fd5','\u1fd6','\u1fd7','\u1fd8','\u1fd9','\u1fda','\u1fdb','\u1fdc','\u1fdd','\u1fde','\u1fdf','\u1fe8','\u1fe9','\u1fe2','\u1fe3','\u1fe4','\u1fec','\u1fe6','\u1fe7','\u1fe8','\u1fe9','\u1fea','\u1feb','\u1fec','\u1fed','\u1fee','\u1fef','\u1ff0','\u1ff1','\u1ff2','\u1ffc' };
		public static readonly char[] range_2170_2184 = new char [] { '\u2160','\u2161','\u2162','\u2163','\u2164','\u2165','\u2166','\u2167','\u2168','\u2169','\u216a','\u216b','\u216c','\u216d','\u216e','\u216f','\u2180','\u2181','\u2182','\u2183','\u2183' };
		public static readonly char[] range_24d0_24e9 = new char [] { '\u24b6','\u24b7','\u24b8','\u24b9','\u24ba','\u24bb','\u24bc','\u24bd','\u24be','\u24bf','\u24c0','\u24c1','\u24c2','\u24c3','\u24c4','\u24c5','\u24c6','\u24c7','\u24c8','\u24c9','\u24ca','\u24cb','\u24cc','\u24cd','\u24ce','\u24cf' };
		public static readonly char[] range_2c30_2ce3 = new char [] { '\u2c00','\u2c01','\u2c02','\u2c03','\u2c04','\u2c05','\u2c06','\u2c07','\u2c08','\u2c09','\u2c0a','\u2c0b','\u2c0c','\u2c0d','\u2c0e','\u2c0f','\u2c10','\u2c11','\u2c12','\u2c13','\u2c14','\u2c15','\u2c16','\u2c17','\u2c18','\u2c19','\u2c1a','\u2c1b','\u2c1c','\u2c1d','\u2c1e','\u2c1f','\u2c20','\u2c21','\u2c22','\u2c23','\u2c24','\u2c25','\u2c26','\u2c27','\u2c28','\u2c29','\u2c2a','\u2c2b','\u2c2c','\u2c2d','\u2c2e','\u2c5f','\u2c60','\u2c60','\u2c62','\u2c63','\u2c64','\u023a','\u023e','\u2c67','\u2c67','\u2c69','\u2c69','\u2c6b','\u2c6b','\u2c6d','\u2c6e','\u2c6f','\u2c70','\u2c71','\u2c72','\u2c72','\u2c74','\u2c75','\u2c75','\u2c77','\u2c78','\u2c79','\u2c7a','\u2c7b','\u2c7c','\u2c7d','\u2c7e','\u2c7f','\u2c80','\u2c80','\u2c82','\u2c82','\u2c84','\u2c84','\u2c86','\u2c86','\u2c88','\u2c88','\u2c8a','\u2c8a','\u2c8c','\u2c8c','\u2c8e','\u2c8e','\u2c90','\u2c90','\u2c92','\u2c92','\u2c94','\u2c94','\u2c96','\u2c96','\u2c98','\u2c98','\u2c9a','\u2c9a','\u2c9c','\u2c9c','\u2c9e','\u2c9e','\u2ca0','\u2ca0','\u2ca2','\u2ca2','\u2ca4','\u2ca4','\u2ca6','\u2ca6','\u2ca8','\u2ca8','\u2caa','\u2caa','\u2cac','\u2cac','\u2cae','\u2cae','\u2cb0','\u2cb0','\u2cb2','\u2cb2','\u2cb4','\u2cb4','\u2cb6','\u2cb6','\u2cb8','\u2cb8','\u2cba','\u2cba','\u2cbc','\u2cbc','\u2cbe','\u2cbe','\u2cc0','\u2cc0','\u2cc2','\u2cc2','\u2cc4','\u2cc4','\u2cc6','\u2cc6','\u2cc8','\u2cc8','\u2cca','\u2cca','\u2ccc','\u2ccc','\u2cce','\u2cce','\u2cd0','\u2cd0','\u2cd2','\u2cd2','\u2cd4','\u2cd4','\u2cd6','\u2cd6','\u2cd8','\u2cd8','\u2cda','\u2cda','\u2cdc','\u2cdc','\u2cde','\u2cde','\u2ce0','\u2ce0','\u2ce2','\u2ce2' };
		public static readonly char[] range_2d00_2d25 = new char [] { '\u10a0','\u10a1','\u10a2','\u10a3','\u10a4','\u10a5','\u10a6','\u10a7','\u10a8','\u10a9','\u10aa','\u10ab','\u10ac','\u10ad','\u10ae','\u10af','\u10b0','\u10b1','\u10b2','\u10b3','\u10b4','\u10b5','\u10b6','\u10b7','\u10b8','\u10b9','\u10ba','\u10bb','\u10bc','\u10bd','\u10be','\u10bf','\u10c0','\u10c1','\u10c2','\u10c3','\u10c4','\u10c5' };
		public static readonly char[] range_a641_a697 = new char [] { '\ua640','\ua642','\ua642','\ua644','\ua644','\ua646','\ua646','\ua648','\ua648','\ua64a','\ua64a','\ua64c','\ua64c','\ua64e','\ua64e','\ua650','\ua650','\ua652','\ua652','\ua654','\ua654','\ua656','\ua656','\ua658','\ua658','\ua65a','\ua65a','\ua65c','\ua65c','\ua65e','\ua65e','\ua660','\ua661','\ua662','\ua662','\ua664','\ua664','\ua666','\ua666','\ua668','\ua668','\ua66a','\ua66a','\ua66c','\ua66c','\ua66e','\ua66f','\ua670','\ua671','\ua672','\ua673','\ua674','\ua675','\ua676','\ua677','\ua678','\ua679','\ua67a','\ua67b','\ua67c','\ua67d','\ua67e','\ua67f','\ua680','\ua680','\ua682','\ua682','\ua684','\ua684','\ua686','\ua686','\ua688','\ua688','\ua68a','\ua68a','\ua68c','\ua68c','\ua68e','\ua68e','\ua690','\ua690','\ua692','\ua692','\ua694','\ua694','\ua696','\ua696' };
		public static readonly char[] range_a723_a78c = new char [] { '\ua722','\ua724','\ua724','\ua726','\ua726','\ua728','\ua728','\ua72a','\ua72a','\ua72c','\ua72c','\ua72e','\ua72e','\ua730','\ua731','\ua732','\ua732','\ua734','\ua734','\ua736','\ua736','\ua738','\ua738','\ua73a','\ua73a','\ua73c','\ua73c','\ua73e','\ua73e','\ua740','\ua740','\ua742','\ua742','\ua744','\ua744','\ua746','\ua746','\ua748','\ua748','\ua74a','\ua74a','\ua74c','\ua74c','\ua74e','\ua74e','\ua750','\ua750','\ua752','\ua752','\ua754','\ua754','\ua756','\ua756','\ua758','\ua758','\ua75a','\ua75a','\ua75c','\ua75c','\ua75e','\ua75e','\ua760','\ua760','\ua762','\ua762','\ua764','\ua764','\ua766','\ua766','\ua768','\ua768','\ua76a','\ua76a','\ua76c','\ua76c','\ua76e','\ua76e','\ua770','\ua771','\ua772','\ua773','\ua774','\ua775','\ua776','\ua777','\ua778','\ua779','\ua779','\ua77b','\ua77b','\ua77d','\ua77e','\ua77e','\ua780','\ua780','\ua782','\ua782','\ua784','\ua784','\ua786','\ua786','\ua788','\ua789','\ua78a','\ua78b','\ua78b' };
	}

	static class TextInfoToLowerData
	{
		public static readonly char[] range_00c0_0556 = new char [] { '\u00e0','\u00e1','\u00e2','\u00e3','\u00e4','\u00e5','\u00e6','\u00e7','\u00e8','\u00e9','\u00ea','\u00eb','\u00ec','\u00ed','\u00ee','\u00ef','\u00f0','\u00f1','\u00f2','\u00f3','\u00f4','\u00f5','\u00f6','\u00d7','\u00f8','\u00f9','\u00fa','\u00fb','\u00fc','\u00fd','\u00fe','\u00df','\u00e0','\u00e1','\u00e2','\u00e3','\u00e4','\u00e5','\u00e6','\u00e7','\u00e8','\u00e9','\u00ea','\u00eb','\u00ec','\u00ed','\u00ee','\u00ef','\u00f0','\u00f1','\u00f2','\u00f3','\u00f4','\u00f5','\u00f6','\u00f7','\u00f8','\u00f9','\u00fa','\u00fb','\u00fc','\u00fd','\u00fe','\u00ff','\u0101','\u0101','\u0103','\u0103','\u0105','\u0105','\u0107','\u0107','\u0109','\u0109','\u010b','\u010b','\u010d','\u010d','\u010f','\u010f','\u0111','\u0111','\u0113','\u0113','\u0115','\u0115','\u0117','\u0117','\u0119','\u0119','\u011b','\u011b','\u011d','\u011d','\u011f','\u011f','\u0121','\u0121','\u0123','\u0123','\u0125','\u0125','\u0127','\u0127','\u0129','\u0129','\u012b','\u012b','\u012d','\u012d','\u012f','\u012f','\u0130','\u0131','\u0133','\u0133','\u0135','\u0135','\u0137','\u0137','\u0138','\u013a','\u013a','\u013c','\u013c','\u013e','\u013e','\u0140','\u0140','\u0142','\u0142','\u0144','\u0144','\u0146','\u0146','\u0148','\u0148','\u0149','\u014b','\u014b','\u014d','\u014d','\u014f','\u014f','\u0151','\u0151','\u0153','\u0153','\u0155','\u0155','\u0157','\u0157','\u0159','\u0159','\u015b','\u015b','\u015d','\u015d','\u015f','\u015f','\u0161','\u0161','\u0163','\u0163','\u0165','\u0165','\u0167','\u0167','\u0169','\u0169','\u016b','\u016b','\u016d','\u016d','\u016f','\u016f','\u0171','\u0171','\u0173','\u0173','\u0175','\u0175','\u0177','\u0177','\u00ff','\u017a','\u017a','\u017c','\u017c','\u017e','\u017e','\u017f','\u0180','\u0253','\u0183','\u0183','\u0185','\u0185','\u0254','\u0188','\u0188','\u0256','\u0257','\u018c','\u018c','\u018d','\u01dd','\u0259','\u025b','\u0192','\u0192','\u0260','\u0263','\u0195','\u0269','\u0268','\u0199','\u0199','\u019a','\u019b','\u026f','\u0272','\u019e','\u0275','\u01a1','\u01a1','\u01a3','\u01a3','\u01a5','\u01a5','\u0280','\u01a8','\u01a8','\u0283','\u01aa','\u01ab','\u01ad','\u01ad','\u0288','\u01b0','\u01b0','\u028a','\u028b','\u01b4','\u01b4','\u01b6','\u01b6','\u0292','\u01b9','\u01b9','\u01ba','\u01bb','\u01bd','\u01bd','\u01be','\u01bf','\u01c0','\u01c1','\u01c2','\u01c3','\u01c6','\u01c5','\u01c6','\u01c9','\u01c8','\u01c9','\u01cc','\u01cb','\u01cc','\u01ce','\u01ce','\u01d0','\u01d0','\u01d2','\u01d2','\u01d4','\u01d4','\u01d6','\u01d6','\u01d8','\u01d8','\u01da','\u01da','\u01dc','\u01dc','\u01dd','\u01df','\u01df','\u01e1','\u01e1','\u01e3','\u01e3','\u01e5','\u01e5','\u01e7','\u01e7','\u01e9','\u01e9','\u01eb','\u01eb','\u01ed','\u01ed','\u01ef','\u01ef','\u01f0','\u01f3','\u01f2','\u01f3','\u01f5','\u01f5','\u0195','\u01bf','\u01f9','\u01f9','\u01fb','\u01fb','\u01fd','\u01fd','\u01ff','\u01ff','\u0201','\u0201','\u0203','\u0203','\u0205','\u0205','\u0207','\u0207','\u0209','\u0209','\u020b','\u020b','\u020d','\u020d','\u020f','\u020f','\u0211','\u0211','\u0213','\u0213','\u0215','\u0215','\u0217','\u0217','\u0219','\u0219','\u021b','\u021b','\u021d','\u021d','\u021f','\u021f','\u019e','\u0221','\u0223','\u0223','\u0225','\u0225','\u0227','\u0227','\u0229','\u0229','\u022b','\u022b','\u022d','\u022d','\u022f','\u022f','\u0231','\u0231','\u0233','\u0233','\u0234','\u0235','\u0236','\u0237','\u0238','\u0239','\u2c65','\u023c','\u023c','\u019a','\u2c66','\u023f','\u0240','\u0242','\u0242','\u0180','\u0289','\u028c','\u0247','\u0247','\u0249','\u0249','\u024b','\u024b','\u024d','\u024d','\u024f','\u024f','\u0250','\u0251','\u0252','\u0253','\u0254','\u0255','\u0256','\u0257','\u0258','\u0259','\u025a','\u025b','\u025c','\u025d','\u025e','\u025f','\u0260','\u0261','\u0262','\u0263','\u0264','\u0265','\u0266','\u0267','\u0268','\u0269','\u026a','\u026b','\u026c','\u026d','\u026e','\u026f','\u0270','\u0271','\u0272','\u0273','\u0274','\u0275','\u0276','\u0277','\u0278','\u0279','\u027a','\u027b','\u027c','\u027d','\u027e','\u027f','\u0280','\u0281','\u0282','\u0283','\u0284','\u0285','\u0286','\u0287','\u0288','\u0289','\u028a','\u028b','\u028c','\u028d','\u028e','\u028f','\u0290','\u0291','\u0292','\u0293','\u0294','\u0295','\u0296','\u0297','\u0298','\u0299','\u029a','\u029b','\u029c','\u029d','\u029e','\u029f','\u02a0','\u02a1','\u02a2','\u02a3','\u02a4','\u02a5','\u02a6','\u02a7','\u02a8','\u02a9','\u02aa','\u02ab','\u02ac','\u02ad','\u02ae','\u02af','\u02b0','\u02b1','\u02b2','\u02b3','\u02b4','\u02b5','\u02b6','\u02b7','\u02b8','\u02b9','\u02ba','\u02bb','\u02bc','\u02bd','\u02be','\u02bf','\u02c0','\u02c1','\u02c2','\u02c3','\u02c4','\u02c5','\u02c6','\u02c7','\u02c8','\u02c9','\u02ca','\u02cb','\u02cc','\u02cd','\u02ce','\u02cf','\u02d0','\u02d1','\u02d2','\u02d3','\u02d4','\u02d5','\u02d6','\u02d7','\u02d8','\u02d9','\u02da','\u02db','\u02dc','\u02dd','\u02de','\u02df','\u02e0','\u02e1','\u02e2','\u02e3','\u02e4','\u02e5','\u02e6','\u02e7','\u02e8','\u02e9','\u02ea','\u02eb','\u02ec','\u02ed','\u02ee','\u02ef','\u02f0','\u02f1','\u02f2','\u02f3','\u02f4','\u02f5','\u02f6','\u02f7','\u02f8','\u02f9','\u02fa','\u02fb','\u02fc','\u02fd','\u02fe','\u02ff','\u0300','\u0301','\u0302','\u0303','\u0304','\u0305','\u0306','\u0307','\u0308','\u0309','\u030a','\u030b','\u030c','\u030d','\u030e','\u030f','\u0310','\u0311','\u0312','\u0313','\u0314','\u0315','\u0316','\u0317','\u0318','\u0319','\u031a','\u031b','\u031c','\u031d','\u031e','\u031f','\u0320','\u0321','\u0322','\u0323','\u0324','\u0325','\u0326','\u0327','\u0328','\u0329','\u032a','\u032b','\u032c','\u032d','\u032e','\u032f','\u0330','\u0331','\u0332','\u0333','\u0334','\u0335','\u0336','\u0337','\u0338','\u0339','\u033a','\u033b','\u033c','\u033d','\u033e','\u033f','\u0340','\u0341','\u0342','\u0343','\u0344','\u0345','\u0346','\u0347','\u0348','\u0349','\u034a','\u034b','\u034c','\u034d','\u034e','\u034f','\u0350','\u0351','\u0352','\u0353','\u0354','\u0355','\u0356','\u0357','\u0358','\u0359','\u035a','\u035b','\u035c','\u035d','\u035e','\u035f','\u0360','\u0361','\u0362','\u0363','\u0364','\u0365','\u0366','\u0367','\u0368','\u0369','\u036a','\u036b','\u036c','\u036d','\u036e','\u036f','\u0371','\u0371','\u0373','\u0373','\u0374','\u0375','\u0377','\u0377','\u0378','\u0379','\u037a','\u037b','\u037c','\u037d','\u037e','\u037f','\u0380','\u0381','\u0382','\u0383','\u0384','\u0385','\u03ac','\u0387','\u03ad','\u03ae','\u03af','\u038b','\u03cc','\u038d','\u03cd','\u03ce','\u0390','\u03b1','\u03b2','\u03b3','\u03b4','\u03b5','\u03b6','\u03b7','\u03b8','\u03b9','\u03ba','\u03bb','\u03bc','\u03bd','\u03be','\u03bf','\u03c0','\u03c1','\u03a2','\u03c3','\u03c4','\u03c5','\u03c6','\u03c7','\u03c8','\u03c9','\u03ca','\u03cb','\u03ac','\u03ad','\u03ae','\u03af','\u03b0','\u03b1','\u03b2','\u03b3','\u03b4','\u03b5','\u03b6','\u03b7','\u03b8','\u03b9','\u03ba','\u03bb','\u03bc','\u03bd','\u03be','\u03bf','\u03c0','\u03c1','\u03c2','\u03c3','\u03c4','\u03c5','\u03c6','\u03c7','\u03c8','\u03c9','\u03ca','\u03cb','\u03cc','\u03cd','\u03ce','\u03d7','\u03d0','\u03d1','\u03d2','\u03d3','\u03d4','\u03d5','\u03d6','\u03d7','\u03d9','\u03d9','\u03db','\u03db','\u03dd','\u03dd','\u03df','\u03df','\u03e1','\u03e1','\u03e3','\u03e3','\u03e5','\u03e5','\u03e7','\u03e7','\u03e9','\u03e9','\u03eb','\u03eb','\u03ed','\u03ed','\u03ef','\u03ef','\u03f0','\u03f1','\u03f2','\u03f3','\u03f4','\u03f5','\u03f6','\u03f8','\u03f8','\u03f2','\u03fb','\u03fb','\u03fc','\u037b','\u037c','\u037d','\u0450','\u0451','\u0452','\u0453','\u0454','\u0455','\u0456','\u0457','\u0458','\u0459','\u045a','\u045b','\u045c','\u045d','\u045e','\u045f','\u0430','\u0431','\u0432','\u0433','\u0434','\u0435','\u0436','\u0437','\u0438','\u0439','\u043a','\u043b','\u043c','\u043d','\u043e','\u043f','\u0440','\u0441','\u0442','\u0443','\u0444','\u0445','\u0446','\u0447','\u0448','\u0449','\u044a','\u044b','\u044c','\u044d','\u044e','\u044f','\u0430','\u0431','\u0432','\u0433','\u0434','\u0435','\u0436','\u0437','\u0438','\u0439','\u043a','\u043b','\u043c','\u043d','\u043e','\u043f','\u0440','\u0441','\u0442','\u0443','\u0444','\u0445','\u0446','\u0447','\u0448','\u0449','\u044a','\u044b','\u044c','\u044d','\u044e','\u044f','\u0450','\u0451','\u0452','\u0453','\u0454','\u0455','\u0456','\u0457','\u0458','\u0459','\u045a','\u045b','\u045c','\u045d','\u045e','\u045f','\u0461','\u0461','\u0463','\u0463','\u0465','\u0465','\u0467','\u0467','\u0469','\u0469','\u046b','\u046b','\u046d','\u046d','\u046f','\u046f','\u0471','\u0471','\u0473','\u0473','\u0475','\u0475','\u0477','\u0477','\u0479','\u0479','\u047b','\u047b','\u047d','\u047d','\u047f','\u047f','\u0481','\u0481','\u0482','\u0483','\u0484','\u0485','\u0486','\u0487','\u0488','\u0489','\u048b','\u048b','\u048d','\u048d','\u048f','\u048f','\u0491','\u0491','\u0493','\u0493','\u0495','\u0495','\u0497','\u0497','\u0499','\u0499','\u049b','\u049b','\u049d','\u049d','\u049f','\u049f','\u04a1','\u04a1','\u04a3','\u04a3','\u04a5','\u04a5','\u04a7','\u04a7','\u04a9','\u04a9','\u04ab','\u04ab','\u04ad','\u04ad','\u04af','\u04af','\u04b1','\u04b1','\u04b3','\u04b3','\u04b5','\u04b5','\u04b7','\u04b7','\u04b9','\u04b9','\u04bb','\u04bb','\u04bd','\u04bd','\u04bf','\u04bf','\u04cf','\u04c2','\u04c2','\u04c4','\u04c4','\u04c6','\u04c6','\u04c8','\u04c8','\u04ca','\u04ca','\u04cc','\u04cc','\u04ce','\u04ce','\u04cf','\u04d1','\u04d1','\u04d3','\u04d3','\u04d5','\u04d5','\u04d7','\u04d7','\u04d9','\u04d9','\u04db','\u04db','\u04dd','\u04dd','\u04df','\u04df','\u04e1','\u04e1','\u04e3','\u04e3','\u04e5','\u04e5','\u04e7','\u04e7','\u04e9','\u04e9','\u04eb','\u04eb','\u04ed','\u04ed','\u04ef','\u04ef','\u04f1','\u04f1','\u04f3','\u04f3','\u04f5','\u04f5','\u04f7','\u04f7','\u04f9','\u04f9','\u04fb','\u04fb','\u04fd','\u04fd','\u04ff','\u04ff','\u0501','\u0501','\u0503','\u0503','\u0505','\u0505','\u0507','\u0507','\u0509','\u0509','\u050b','\u050b','\u050d','\u050d','\u050f','\u050f','\u0511','\u0511','\u0513','\u0513','\u0515','\u0515','\u0517','\u0517','\u0519','\u0519','\u051b','\u051b','\u051d','\u051d','\u051f','\u051f','\u0521','\u0521','\u0523','\u0523','\u0524','\u0525','\u0526','\u0527','\u0528','\u0529','\u052a','\u052b','\u052c','\u052d','\u052e','\u052f','\u0530','\u0561','\u0562','\u0563','\u0564','\u0565','\u0566','\u0567','\u0568','\u0569','\u056a','\u056b','\u056c','\u056d','\u056e','\u056f','\u0570','\u0571','\u0572','\u0573','\u0574','\u0575','\u0576','\u0577','\u0578','\u0579','\u057a','\u057b','\u057c','\u057d','\u057e','\u057f','\u0580','\u0581','\u0582','\u0583','\u0584','\u0585','\u0586' };
		public static readonly char[] range_10a0_10c5 = new char [] { '\u2d00','\u2d01','\u2d02','\u2d03','\u2d04','\u2d05','\u2d06','\u2d07','\u2d08','\u2d09','\u2d0a','\u2d0b','\u2d0c','\u2d0d','\u2d0e','\u2d0f','\u2d10','\u2d11','\u2d12','\u2d13','\u2d14','\u2d15','\u2d16','\u2d17','\u2d18','\u2d19','\u2d1a','\u2d1b','\u2d1c','\u2d1d','\u2d1e','\u2d1f','\u2d20','\u2d21','\u2d22','\u2d23','\u2d24','\u2d25' };
		public static readonly char[] range_1e00_1ffc = new char [] { '\u1e01','\u1e01','\u1e03','\u1e03','\u1e05','\u1e05','\u1e07','\u1e07','\u1e09','\u1e09','\u1e0b','\u1e0b','\u1e0d','\u1e0d','\u1e0f','\u1e0f','\u1e11','\u1e11','\u1e13','\u1e13','\u1e15','\u1e15','\u1e17','\u1e17','\u1e19','\u1e19','\u1e1b','\u1e1b','\u1e1d','\u1e1d','\u1e1f','\u1e1f','\u1e21','\u1e21','\u1e23','\u1e23','\u1e25','\u1e25','\u1e27','\u1e27','\u1e29','\u1e29','\u1e2b','\u1e2b','\u1e2d','\u1e2d','\u1e2f','\u1e2f','\u1e31','\u1e31','\u1e33','\u1e33','\u1e35','\u1e35','\u1e37','\u1e37','\u1e39','\u1e39','\u1e3b','\u1e3b','\u1e3d','\u1e3d','\u1e3f','\u1e3f','\u1e41','\u1e41','\u1e43','\u1e43','\u1e45','\u1e45','\u1e47','\u1e47','\u1e49','\u1e49','\u1e4b','\u1e4b','\u1e4d','\u1e4d','\u1e4f','\u1e4f','\u1e51','\u1e51','\u1e53','\u1e53','\u1e55','\u1e55','\u1e57','\u1e57','\u1e59','\u1e59','\u1e5b','\u1e5b','\u1e5d','\u1e5d','\u1e5f','\u1e5f','\u1e61','\u1e61','\u1e63','\u1e63','\u1e65','\u1e65','\u1e67','\u1e67','\u1e69','\u1e69','\u1e6b','\u1e6b','\u1e6d','\u1e6d','\u1e6f','\u1e6f','\u1e71','\u1e71','\u1e73','\u1e73','\u1e75','\u1e75','\u1e77','\u1e77','\u1e79','\u1e79','\u1e7b','\u1e7b','\u1e7d','\u1e7d','\u1e7f','\u1e7f','\u1e81','\u1e81','\u1e83','\u1e83','\u1e85','\u1e85','\u1e87','\u1e87','\u1e89','\u1e89','\u1e8b','\u1e8b','\u1e8d','\u1e8d','\u1e8f','\u1e8f','\u1e91','\u1e91','\u1e93','\u1e93','\u1e95','\u1e95','\u1e96','\u1e97','\u1e98','\u1e99','\u1e9a','\u1e9b','\u1e9c','\u1e9d','\u1e9e','\u1e9f','\u1ea1','\u1ea1','\u1ea3','\u1ea3','\u1ea5','\u1ea5','\u1ea7','\u1ea7','\u1ea9','\u1ea9','\u1eab','\u1eab','\u1ead','\u1ead','\u1eaf','\u1eaf','\u1eb1','\u1eb1','\u1eb3','\u1eb3','\u1eb5','\u1eb5','\u1eb7','\u1eb7','\u1eb9','\u1eb9','\u1ebb','\u1ebb','\u1ebd','\u1ebd','\u1ebf','\u1ebf','\u1ec1','\u1ec1','\u1ec3','\u1ec3','\u1ec5','\u1ec5','\u1ec7','\u1ec7','\u1ec9','\u1ec9','\u1ecb','\u1ecb','\u1ecd','\u1ecd','\u1ecf','\u1ecf','\u1ed1','\u1ed1','\u1ed3','\u1ed3','\u1ed5','\u1ed5','\u1ed7','\u1ed7','\u1ed9','\u1ed9','\u1edb','\u1edb','\u1edd','\u1edd','\u1edf','\u1edf','\u1ee1','\u1ee1','\u1ee3','\u1ee3','\u1ee5','\u1ee5','\u1ee7','\u1ee7','\u1ee9','\u1ee9','\u1eeb','\u1eeb','\u1eed','\u1eed','\u1eef','\u1eef','\u1ef1','\u1ef1','\u1ef3','\u1ef3','\u1ef5','\u1ef5','\u1ef7','\u1ef7','\u1ef9','\u1ef9','\u1efb','\u1efb','\u1efd','\u1efd','\u1eff','\u1eff','\u1f00','\u1f01','\u1f02','\u1f03','\u1f04','\u1f05','\u1f06','\u1f07','\u1f00','\u1f01','\u1f02','\u1f03','\u1f04','\u1f05','\u1f06','\u1f07','\u1f10','\u1f11','\u1f12','\u1f13','\u1f14','\u1f15','\u1f16','\u1f17','\u1f10','\u1f11','\u1f12','\u1f13','\u1f14','\u1f15','\u1f1e','\u1f1f','\u1f20','\u1f21','\u1f22','\u1f23','\u1f24','\u1f25','\u1f26','\u1f27','\u1f20','\u1f21','\u1f22','\u1f23','\u1f24','\u1f25','\u1f26','\u1f27','\u1f30','\u1f31','\u1f32','\u1f33','\u1f34','\u1f35','\u1f36','\u1f37','\u1f30','\u1f31','\u1f32','\u1f33','\u1f34','\u1f35','\u1f36','\u1f37','\u1f40','\u1f41','\u1f42','\u1f43','\u1f44','\u1f45','\u1f46','\u1f47','\u1f40','\u1f41','\u1f42','\u1f43','\u1f44','\u1f45','\u1f4e','\u1f4f','\u1f50','\u1f51','\u1f52','\u1f53','\u1f54','\u1f55','\u1f56','\u1f57','\u1f58','\u1f51','\u1f5a','\u1f53','\u1f5c','\u1f55','\u1f5e','\u1f57','\u1f60','\u1f61','\u1f62','\u1f63','\u1f64','\u1f65','\u1f66','\u1f67','\u1f60','\u1f61','\u1f62','\u1f63','\u1f64','\u1f65','\u1f66','\u1f67','\u1f70','\u1f71','\u1f72','\u1f73','\u1f74','\u1f75','\u1f76','\u1f77','\u1f78','\u1f79','\u1f7a','\u1f7b','\u1f7c','\u1f7d','\u1f7e','\u1f7f','\u1f80','\u1f81','\u1f82','\u1f83','\u1f84','\u1f85','\u1f86','\u1f87','\u1f80','\u1f81','\u1f82','\u1f83','\u1f84','\u1f85','\u1f86','\u1f87','\u1f90','\u1f91','\u1f92','\u1f93','\u1f94','\u1f95','\u1f96','\u1f97','\u1f90','\u1f91','\u1f92','\u1f93','\u1f94','\u1f95','\u1f96','\u1f97','\u1fa0','\u1fa1','\u1fa2','\u1fa3','\u1fa4','\u1fa5','\u1fa6','\u1fa7','\u1fa0','\u1fa1','\u1fa2','\u1fa3','\u1fa4','\u1fa5','\u1fa6','\u1fa7','\u1fb0','\u1fb1','\u1fb2','\u1fb3','\u1fb4','\u1fb5','\u1fb6','\u1fb7','\u1fb0','\u1fb1','\u1f70','\u1f71','\u1fb3','\u1fbd','\u1fbe','\u1fbf','\u1fc0','\u1fc1','\u1fc2','\u1fc3','\u1fc4','\u1fc5','\u1fc6','\u1fc7','\u1f72','\u1f73','\u1f74','\u1f75','\u1fc3','\u1fcd','\u1fce','\u1fcf','\u1fd0','\u1fd1','\u1fd2','\u1fd3','\u1fd4','\u1fd5','\u1fd6','\u1fd7','\u1fd0','\u1fd1','\u1f76','\u1f77','\u1fdc','\u1fdd','\u1fde','\u1fdf','\u1fe0','\u1fe1','\u1fe2','\u1fe3','\u1fe4','\u1fe5','\u1fe6','\u1fe7','\u1fe0','\u1fe1','\u1f7a','\u1f7b','\u1fe5','\u1fed','\u1fee','\u1fef','\u1ff0','\u1ff1','\u1ff2','\u1ff3','\u1ff4','\u1ff5','\u1ff6','\u1ff7','\u1f78','\u1f79','\u1f7c','\u1f7d','\u1ff3' };
		public static readonly char[] range_2160_216f = new char [] { '\u2170','\u2171','\u2172','\u2173','\u2174','\u2175','\u2176','\u2177','\u2178','\u2179','\u217a','\u217b','\u217c','\u217d','\u217e','\u217f' };
		public static readonly char[] range_24b6_24cf = new char [] { '\u24d0','\u24d1','\u24d2','\u24d3','\u24d4','\u24d5','\u24d6','\u24d7','\u24d8','\u24d9','\u24da','\u24db','\u24dc','\u24dd','\u24de','\u24df','\u24e0','\u24e1','\u24e2','\u24e3','\u24e4','\u24e5','\u24e6','\u24e7','\u24e8','\u24e9' };
		public static readonly char[] range_2c00_2c2e = new char [] { '\u2c30','\u2c31','\u2c32','\u2c33','\u2c34','\u2c35','\u2c36','\u2c37','\u2c38','\u2c39','\u2c3a','\u2c3b','\u2c3c','\u2c3d','\u2c3e','\u2c3f','\u2c40','\u2c41','\u2c42','\u2c43','\u2c44','\u2c45','\u2c46','\u2c47','\u2c48','\u2c49','\u2c4a','\u2c4b','\u2c4c','\u2c4d','\u2c4e','\u2c4f','\u2c50','\u2c51','\u2c52','\u2c53','\u2c54','\u2c55','\u2c56','\u2c57','\u2c58','\u2c59','\u2c5a','\u2c5b','\u2c5c','\u2c5d','\u2c5e' };
		public static readonly char[] range_2c60_2ce2 = new char [] { '\u2c61','\u2c61','\u026b','\u1d7d','\u027d','\u2c65','\u2c66','\u2c68','\u2c68','\u2c6a','\u2c6a','\u2c6c','\u2c6c','\u0251','\u0271','\u0250','\u2c70','\u2c71','\u2c73','\u2c73','\u2c74','\u2c76','\u2c76','\u2c77','\u2c78','\u2c79','\u2c7a','\u2c7b','\u2c7c','\u2c7d','\u2c7e','\u2c7f','\u2c81','\u2c81','\u2c83','\u2c83','\u2c85','\u2c85','\u2c87','\u2c87','\u2c89','\u2c89','\u2c8b','\u2c8b','\u2c8d','\u2c8d','\u2c8f','\u2c8f','\u2c91','\u2c91','\u2c93','\u2c93','\u2c95','\u2c95','\u2c97','\u2c97','\u2c99','\u2c99','\u2c9b','\u2c9b','\u2c9d','\u2c9d','\u2c9f','\u2c9f','\u2ca1','\u2ca1','\u2ca3','\u2ca3','\u2ca5','\u2ca5','\u2ca7','\u2ca7','\u2ca9','\u2ca9','\u2cab','\u2cab','\u2cad','\u2cad','\u2caf','\u2caf','\u2cb1','\u2cb1','\u2cb3','\u2cb3','\u2cb5','\u2cb5','\u2cb7','\u2cb7','\u2cb9','\u2cb9','\u2cbb','\u2cbb','\u2cbd','\u2cbd','\u2cbf','\u2cbf','\u2cc1','\u2cc1','\u2cc3','\u2cc3','\u2cc5','\u2cc5','\u2cc7','\u2cc7','\u2cc9','\u2cc9','\u2ccb','\u2ccb','\u2ccd','\u2ccd','\u2ccf','\u2ccf','\u2cd1','\u2cd1','\u2cd3','\u2cd3','\u2cd5','\u2cd5','\u2cd7','\u2cd7','\u2cd9','\u2cd9','\u2cdb','\u2cdb','\u2cdd','\u2cdd','\u2cdf','\u2cdf','\u2ce1','\u2ce1','\u2ce3' };
		public static readonly char[] range_a640_a696 = new char [] { '\ua641','\ua641','\ua643','\ua643','\ua645','\ua645','\ua647','\ua647','\ua649','\ua649','\ua64b','\ua64b','\ua64d','\ua64d','\ua64f','\ua64f','\ua651','\ua651','\ua653','\ua653','\ua655','\ua655','\ua657','\ua657','\ua659','\ua659','\ua65b','\ua65b','\ua65d','\ua65d','\ua65f','\ua65f','\ua660','\ua661','\ua663','\ua663','\ua665','\ua665','\ua667','\ua667','\ua669','\ua669','\ua66b','\ua66b','\ua66d','\ua66d','\ua66e','\ua66f','\ua670','\ua671','\ua672','\ua673','\ua674','\ua675','\ua676','\ua677','\ua678','\ua679','\ua67a','\ua67b','\ua67c','\ua67d','\ua67e','\ua67f','\ua681','\ua681','\ua683','\ua683','\ua685','\ua685','\ua687','\ua687','\ua689','\ua689','\ua68b','\ua68b','\ua68d','\ua68d','\ua68f','\ua68f','\ua691','\ua691','\ua693','\ua693','\ua695','\ua695','\ua697' };
		public static readonly char[] range_a722_a78b = new char [] { '\ua723','\ua723','\ua725','\ua725','\ua727','\ua727','\ua729','\ua729','\ua72b','\ua72b','\ua72d','\ua72d','\ua72f','\ua72f','\ua730','\ua731','\ua733','\ua733','\ua735','\ua735','\ua737','\ua737','\ua739','\ua739','\ua73b','\ua73b','\ua73d','\ua73d','\ua73f','\ua73f','\ua741','\ua741','\ua743','\ua743','\ua745','\ua745','\ua747','\ua747','\ua749','\ua749','\ua74b','\ua74b','\ua74d','\ua74d','\ua74f','\ua74f','\ua751','\ua751','\ua753','\ua753','\ua755','\ua755','\ua757','\ua757','\ua759','\ua759','\ua75b','\ua75b','\ua75d','\ua75d','\ua75f','\ua75f','\ua761','\ua761','\ua763','\ua763','\ua765','\ua765','\ua767','\ua767','\ua769','\ua769','\ua76b','\ua76b','\ua76d','\ua76d','\ua76f','\ua76f','\ua770','\ua771','\ua772','\ua773','\ua774','\ua775','\ua776','\ua777','\ua778','\ua77a','\ua77a','\ua77c','\ua77c','\u1d79','\ua77f','\ua77f','\ua781','\ua781','\ua783','\ua783','\ua785','\ua785','\ua787','\ua787','\ua788','\ua789','\ua78a','\ua78c' };
	}
}