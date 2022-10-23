using System;
using System.IO;

namespace ix4l
{
	class Program
	{
		public static string path;
		
		public static void Main(string[] args)
		{
			bool have = false;
			foreach(string l in args)
            {
            	string s = l;
            	if(s.StartsWith("FILE:"))
        		{
        			s = s.Remove(0, 5);
        			if(File.Exists(s))
            		{
        				if(s.EndsWith(".ix4l"))
        				{
		        			path = s;
		        			have = true;
        				}
        				else if(s.EndsWith(".ix4l\""))
        				{
		        			path = s;
		        			have = true;
        				}
            		}
            		else
            		{
            			Console.WriteLine("NOT FOUND FILE " + s);
            			Console.ReadKey();
    					Environment.Exit(0);
            		}
            		break;
        		}
        		else
        		{
        			Console.WriteLine("NOT FOUND ARGUMENT " + s);
        			Console.ReadKey();
					Environment.Exit(0);
        		}
            }
            if(!have)
            {
	            if(File.Exists("SOURCE.ix4l"))
	        		path = "SOURCE.ix4l";
	        	else
	        	{
	        		Console.WriteLine("NOT FOUND FILE SOURCE.ix4l");
	            	Console.ReadKey();
	        		Environment.Exit(0);
	        	}
            }
            
            oth(0);
		}
		
		public static void oth(int stat)
		{
			/*
			01010000010100100100100101001110010101000100110001001001010011100100010101010100010001010101100001010100
			printlinetext
			01010010010001010100000101000100010010110100010101011001
			pause
			010000110100110001000101010000010101001001010100010001010101100001010100
			cleartext
			01010111010010010100111001000100010011110101011101000011010000010101000001010100010010010100111101001110
			windowcaption
			010101110101001001001001010101000100010101001100010010010100111001000101010010010100111001000110010010010100110001000101
			writelineinfile:path<<<#>>>text<<<#>>>line(<<<!!!!!!>>>#NEWFILE#$ix4l\\\)
			010101110101001001001001010101000100010101001100010010010100111001000101010010010100111001000110010010010100110001000101
			iftextinfile
			010100000101001001001001010011100101010001001100010010010100111001000101010101000100010101011000010101000100011001010010010011110100110101000110010010010100110001000101
			printlinetextfromfile
			010101000100111101001100010010010100111001000101
			toline
			010000110100100001001111010011110101001101000101010101000100111101001100010010010100111001000101
			choosetoline
			0100010101011000010010010101010001000110010100100100111101001101010000010101000001010000
			exitfromapp
			*/
			string[] l = File.ReadAllLines(path);
			for(int i = stat; i < l.Length; i++)
			{
				try
				{
					if(l[i].StartsWith("01010000010100100100100101001110010101000100110001001001010011100100010101010100010001010101100001010100:"))
					{
						string ofas = l[i].Remove(0, "01010000010100100100100101001110010101000100110001001001010011100100010101010100010001010101100001010100:".Length);
						if(ofas == @"<<<!!!!!!>>>#NEWLINE#$ix4l\\\")
							Console.Write(Environment.NewLine);
						else
							Console.Write(ofas);
						
					}
					else if(l[i] == "01010010010001010100000101000100010010110100010101011001")
						Console.ReadKey(true);
					else if (l[i] == "010000110100110001000101010000010101001001010100010001010101100001010100")
	                    Console.Clear();
	                else if (l[i] == "0100010101011000010010010101010001000110010100100100111101001101010000010101000001010000")
	                	Environment.Exit(0);
	                else if(l[i].StartsWith("010101110101001001001001010101000100010101001100010010010100111001000101010010010100111001000110010010010100110001000101:"))
					{
						string def = l[i].Remove(0, "010101110101001001001001010101000100010101001100010010010100111001000101010010010100111001000110010010010100110001000101:".Length);
						string file = def.Substring(0, def.IndexOf("="));
						string j = def.Substring(def.IndexOf("=") + 1);
						string text = j.Substring(0, j.IndexOf(" "));
						string ln = j.Substring(j.IndexOf(" ") + 1);
						if(File.Exists(file))
						{
							string fltxt = File.ReadAllText(file);
							if(fltxt == text)
							{
								int la = 0;
								try
								{
									la = int.Parse(ln);
								}
								catch
								{
									
								}
								if(la < l.Length)
								{
									oth(la);
								}
							}
						}
					}
	                else if(l[i].StartsWith("010101000100111101001100010010010100111001000101:"))
					{
						string ofas = l[i].Remove(0, "010101000100111101001100010010010100111001000101:".Length);
						int la = 0;
						try
						{
							la = int.Parse(ofas);
						}
						catch
						{
							
						}
						if(la < l.Length)
						{
							oth(la);
						}
					}
	                else if(l[i].StartsWith("010000110100100001001111010011110101001101000101010101000100111101001100010010010100111001000101:"))
					{
						string ofasa = l[i].Remove(0, "010000110100100001001111010011110101001101000101010101000100111101001100010010010100111001000101:".Length);
						Console.Write(ofasa); string ofas = Console.ReadLine();
						int la = 0;
						try
						{
							la = int.Parse(ofas);
						}
						catch
						{
							
						}
						if(la < l.Length)
						{
							oth(la);
						}
					}
 	                else if(l[i].StartsWith("01010111010010010100111001000100010011110101011101000011010000010101000001010100010010010100111101001110:"))
					{
						string ofas = l[i].Remove(0, "01010111010010010100111001000100010011110101011101000011010000010101000001010100010010010100111101001110:".Length);
						if(ofas == @"<<<!!!!!!>>>#CAPTION#$ix4l\\\")
							Console.Title = "11010000101011011101000010100010110100001001111000100000110100001001000111010000100101011101000010100001110100001001111111010000100111101101000010011011110100001001010111010000100101111101000010011101110100001010101111010000100110010010000011010000101000101101000010010101110100001001101011010000101000011101000010100010001000000101011101001000010110010010000001011001010011110101010100100000010100100100010101000001010001000010000001010100010010000100100101010011";
						else
							Console.Title = ofas;
					}
	                else if(l[i].StartsWith("010101110101001001001001010101000100010101001100010010010100111001000101010010010100111001000110010010010100110001000101:"))
					{
						string ofaas = l[i].Remove(0, "010101110101001001001001010101000100010101001100010010010100111001000101010010010100111001000110010010010100110001000101:".Length);
						string[] splitstring = { "<<<#>>>" };
						string[] ofas = ofaas.Split(splitstring, StringSplitOptions.None);
						if(ofas.Length == 2)
						{
							if(ofas[2] == @"<<<!!!!!!>>>#NEWFILE#$ix4l\\\")
								File.WriteAllText(ofas[0], ofas[1]);
							else
							{
								string[] adaida = File.ReadAllLines(ofas[0]);
								int lad = 0;
								try
								{
									lad = int.Parse(ofas[2]);
								}
								catch
								{
									
								}
								if(lad < adaida.Length)
								{
									adaida[lad] = ofas[1];
								}
								File.WriteAllLines(ofas[0], adaida);
							}
						}
					}
	                else if(l[i].StartsWith("010100000101001001001001010011100101010001001100010010010100111001000101010101000100010101011000010101000100011001010010010011110100110101000110010010010100110001000101:"))
					{
						string ofas = l[i].Remove(0, "010100000101001001001001010011100101010001001100010010010100111001000101010101000100010101011000010101000100011001010010010011110100110101000110010010010100110001000101:".Length);
						if(File.Exists(ofas))
						{
							string[] texts = File.ReadAllLines(ofas);
							foreach(string cada in texts)
								Console.WriteLine(cada);
						}
					} 
				}
				catch
				{
					continue;
				}
			}
		}
	}
}