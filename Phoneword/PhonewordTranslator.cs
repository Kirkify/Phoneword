﻿using System;
using System.Text;

namespace Phoneword
{
	public static class PhonewordTranslator
	{
		public static string ToNumber(string raw)
		{
			if (string.IsNullOrWhiteSpace(raw))
			{
				return null;
			}

			raw = raw.ToUpperInvariant();

			var newNumber = new StringBuilder();

			foreach (var item in raw)
			{
				if (" -0123456789".Contains(item))
				{
					newNumber.Append(item);
				}
				else
				{
					var result = TranslateToNumber(item);
					if (result != null)
					{
						newNumber.Append(result);
					}
					// Bad character
					else
					{
						return null;
					}
				}
			}
			return newNumber.ToString();
		}

		static bool Contains(this string keyString, char c)
		{
			return keyString.IndexOf(c) >= 0;
		}

		static readonly string[] digits = {
			"ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
		};

		static int? TranslateToNumber(char c)
		{
			for (int i = 0; i < digits.Length; i++)
			{
				if (digits[i].Contains(c))
					return 2 + i;
			}
			return null;
		}
	}
}