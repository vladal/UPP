﻿
using System;
using System.Data.SqlClient;
using V82;
using V82.ДокументыСсылка;
using V82.Документы;//Менеджер;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.Документы//Менеджер
{
	///<summary>
	///(Регл)
	///</summary>
	public partial class РасчетыПоСтраховымВзносам:ДокументМенеджер
	{
		
		public static ДокументыСсылка.РасчетыПоСтраховымВзносам НайтиПоСсылке(Guid _Ссылка)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld24942RRef [Организация]
					,_Fld24943 [Комментарий]
					,_Fld24944RRef [Ответственный]
					,_Fld24945RRef [ВидПлатежа]
					,_Fld24946 [ДатаПлатежа]
					,_Fld24947 [МесяцРасчетногоПериода]
					,_Fld24948 [ПФРСтраховая]
					,_Fld24949 [ПФРНакопительная]
					,_Fld24950 [ФСС]
					,_Fld24951 [ФФОМС]
					,_Fld24952 [ТФОМС]
					,_Fld24953 [ФССНесчастныеСлучаи]
					,_Fld24954 [ПФРПоДополнительномуТарифу]
					,_Fld24955 [ПлатежноеПоручениеФССНомер]
					,_Fld24956 [ПлатежноеПоручениеФСС_НС_ПЗНомер]
					,_Fld24957RRef [ВидОперации]
					,_Fld24958 [ПлатежноеПоручениеФССДата]
					,_Fld24959 [ПлатежноеПоручениеФСС_НС_ПЗДата]
					,_Fld24960 [ФССЕНВД]
					,_Fld24961 [ПФРНаДоплатуКПенсииШахтерам]
					From _Document23165(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РасчетыПоСтраховымВзносам();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.ДатаПлатежа = Читалка.GetDateTime(7);
							Ссылка.МесяцРасчетногоПериода = Читалка.GetDateTime(8);
							Ссылка.ПФРСтраховая = Читалка.GetDecimal(9);
							Ссылка.ПФРНакопительная = Читалка.GetDecimal(10);
							Ссылка.ФСС = Читалка.GetDecimal(11);
							Ссылка.ФФОМС = Читалка.GetDecimal(12);
							Ссылка.ТФОМС = Читалка.GetDecimal(13);
							Ссылка.ФССНесчастныеСлучаи = Читалка.GetDecimal(14);
							Ссылка.ПФРПоДополнительномуТарифу = Читалка.GetDecimal(15);
							Ссылка.ПлатежноеПоручениеФССНомер = Читалка.GetString(16);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗНомер = Читалка.GetString(17);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка.Получить((byte[])Читалка.GetValue(18));
							Ссылка.ПлатежноеПоручениеФССДата = Читалка.GetDateTime(19);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗДата = Читалка.GetDateTime(20);
							Ссылка.ФССЕНВД = Читалка.GetDecimal(21);
							Ссылка.ПФРНаДоплатуКПенсииШахтерам = Читалка.GetDecimal(22);
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыСсылка.РасчетыПоСтраховымВзносам НайтиПоНомеру(string Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld24942RRef [Организация]
					,_Fld24943 [Комментарий]
					,_Fld24944RRef [Ответственный]
					,_Fld24945RRef [ВидПлатежа]
					,_Fld24946 [ДатаПлатежа]
					,_Fld24947 [МесяцРасчетногоПериода]
					,_Fld24948 [ПФРСтраховая]
					,_Fld24949 [ПФРНакопительная]
					,_Fld24950 [ФСС]
					,_Fld24951 [ФФОМС]
					,_Fld24952 [ТФОМС]
					,_Fld24953 [ФССНесчастныеСлучаи]
					,_Fld24954 [ПФРПоДополнительномуТарифу]
					,_Fld24955 [ПлатежноеПоручениеФССНомер]
					,_Fld24956 [ПлатежноеПоручениеФСС_НС_ПЗНомер]
					,_Fld24957RRef [ВидОперации]
					,_Fld24958 [ПлатежноеПоручениеФССДата]
					,_Fld24959 [ПлатежноеПоручениеФСС_НС_ПЗДата]
					,_Fld24960 [ФССЕНВД]
					,_Fld24961 [ПФРНаДоплатуКПенсииШахтерам]
					From _Document23165(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РасчетыПоСтраховымВзносам();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.ДатаПлатежа = Читалка.GetDateTime(7);
							Ссылка.МесяцРасчетногоПериода = Читалка.GetDateTime(8);
							Ссылка.ПФРСтраховая = Читалка.GetDecimal(9);
							Ссылка.ПФРНакопительная = Читалка.GetDecimal(10);
							Ссылка.ФСС = Читалка.GetDecimal(11);
							Ссылка.ФФОМС = Читалка.GetDecimal(12);
							Ссылка.ТФОМС = Читалка.GetDecimal(13);
							Ссылка.ФССНесчастныеСлучаи = Читалка.GetDecimal(14);
							Ссылка.ПФРПоДополнительномуТарифу = Читалка.GetDecimal(15);
							Ссылка.ПлатежноеПоручениеФССНомер = Читалка.GetString(16);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗНомер = Читалка.GetString(17);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка.Получить((byte[])Читалка.GetValue(18));
							Ссылка.ПлатежноеПоручениеФССДата = Читалка.GetDateTime(19);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗДата = Читалка.GetDateTime(20);
							Ссылка.ФССЕНВД = Читалка.GetDecimal(21);
							Ссылка.ПФРНаДоплатуКПенсииШахтерам = Читалка.GetDecimal(22);
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыВыборка.РасчетыПоСтраховымВзносам Выбрать()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld24942RRef [Организация]
					,_Fld24943 [Комментарий]
					,_Fld24944RRef [Ответственный]
					,_Fld24945RRef [ВидПлатежа]
					,_Fld24946 [ДатаПлатежа]
					,_Fld24947 [МесяцРасчетногоПериода]
					,_Fld24948 [ПФРСтраховая]
					,_Fld24949 [ПФРНакопительная]
					,_Fld24950 [ФСС]
					,_Fld24951 [ФФОМС]
					,_Fld24952 [ТФОМС]
					,_Fld24953 [ФССНесчастныеСлучаи]
					,_Fld24954 [ПФРПоДополнительномуТарифу]
					,_Fld24955 [ПлатежноеПоручениеФССНомер]
					,_Fld24956 [ПлатежноеПоручениеФСС_НС_ПЗНомер]
					,_Fld24957RRef [ВидОперации]
					,_Fld24958 [ПлатежноеПоручениеФССДата]
					,_Fld24959 [ПлатежноеПоручениеФСС_НС_ПЗДата]
					,_Fld24960 [ФССЕНВД]
					,_Fld24961 [ПФРНаДоплатуКПенсииШахтерам]
					From _Document23165(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РасчетыПоСтраховымВзносам();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РасчетыПоСтраховымВзносам();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.ДатаПлатежа = Читалка.GetDateTime(7);
							Ссылка.МесяцРасчетногоПериода = Читалка.GetDateTime(8);
							Ссылка.ПФРСтраховая = Читалка.GetDecimal(9);
							Ссылка.ПФРНакопительная = Читалка.GetDecimal(10);
							Ссылка.ФСС = Читалка.GetDecimal(11);
							Ссылка.ФФОМС = Читалка.GetDecimal(12);
							Ссылка.ТФОМС = Читалка.GetDecimal(13);
							Ссылка.ФССНесчастныеСлучаи = Читалка.GetDecimal(14);
							Ссылка.ПФРПоДополнительномуТарифу = Читалка.GetDecimal(15);
							Ссылка.ПлатежноеПоручениеФССНомер = Читалка.GetString(16);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗНомер = Читалка.GetString(17);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка.Получить((byte[])Читалка.GetValue(18));
							Ссылка.ПлатежноеПоручениеФССДата = Читалка.GetDateTime(19);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗДата = Читалка.GetDateTime(20);
							Ссылка.ФССЕНВД = Читалка.GetDecimal(21);
							Ссылка.ПФРНаДоплатуКПенсииШахтерам = Читалка.GetDecimal(22);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РасчетыПоСтраховымВзносам ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld24942RRef [Организация]
					,_Fld24943 [Комментарий]
					,_Fld24944RRef [Ответственный]
					,_Fld24945RRef [ВидПлатежа]
					,_Fld24946 [ДатаПлатежа]
					,_Fld24947 [МесяцРасчетногоПериода]
					,_Fld24948 [ПФРСтраховая]
					,_Fld24949 [ПФРНакопительная]
					,_Fld24950 [ФСС]
					,_Fld24951 [ФФОМС]
					,_Fld24952 [ТФОМС]
					,_Fld24953 [ФССНесчастныеСлучаи]
					,_Fld24954 [ПФРПоДополнительномуТарифу]
					,_Fld24955 [ПлатежноеПоручениеФССНомер]
					,_Fld24956 [ПлатежноеПоручениеФСС_НС_ПЗНомер]
					,_Fld24957RRef [ВидОперации]
					,_Fld24958 [ПлатежноеПоручениеФССДата]
					,_Fld24959 [ПлатежноеПоручениеФСС_НС_ПЗДата]
					,_Fld24960 [ФССЕНВД]
					,_Fld24961 [ПФРНаДоплатуКПенсииШахтерам]
					From _Document23165(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РасчетыПоСтраховымВзносам();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РасчетыПоСтраховымВзносам();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.ДатаПлатежа = Читалка.GetDateTime(7);
							Ссылка.МесяцРасчетногоПериода = Читалка.GetDateTime(8);
							Ссылка.ПФРСтраховая = Читалка.GetDecimal(9);
							Ссылка.ПФРНакопительная = Читалка.GetDecimal(10);
							Ссылка.ФСС = Читалка.GetDecimal(11);
							Ссылка.ФФОМС = Читалка.GetDecimal(12);
							Ссылка.ТФОМС = Читалка.GetDecimal(13);
							Ссылка.ФССНесчастныеСлучаи = Читалка.GetDecimal(14);
							Ссылка.ПФРПоДополнительномуТарифу = Читалка.GetDecimal(15);
							Ссылка.ПлатежноеПоручениеФССНомер = Читалка.GetString(16);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗНомер = Читалка.GetString(17);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка.Получить((byte[])Читалка.GetValue(18));
							Ссылка.ПлатежноеПоручениеФССДата = Читалка.GetDateTime(19);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗДата = Читалка.GetDateTime(20);
							Ссылка.ФССЕНВД = Читалка.GetDecimal(21);
							Ссылка.ПФРНаДоплатуКПенсииШахтерам = Читалка.GetDecimal(22);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РасчетыПоСтраховымВзносам ВыбратьПоНомеру(int Первые,string Мин,string Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld24942RRef [Организация]
					,_Fld24943 [Комментарий]
					,_Fld24944RRef [Ответственный]
					,_Fld24945RRef [ВидПлатежа]
					,_Fld24946 [ДатаПлатежа]
					,_Fld24947 [МесяцРасчетногоПериода]
					,_Fld24948 [ПФРСтраховая]
					,_Fld24949 [ПФРНакопительная]
					,_Fld24950 [ФСС]
					,_Fld24951 [ФФОМС]
					,_Fld24952 [ТФОМС]
					,_Fld24953 [ФССНесчастныеСлучаи]
					,_Fld24954 [ПФРПоДополнительномуТарифу]
					,_Fld24955 [ПлатежноеПоручениеФССНомер]
					,_Fld24956 [ПлатежноеПоручениеФСС_НС_ПЗНомер]
					,_Fld24957RRef [ВидОперации]
					,_Fld24958 [ПлатежноеПоручениеФССДата]
					,_Fld24959 [ПлатежноеПоручениеФСС_НС_ПЗДата]
					,_Fld24960 [ФССЕНВД]
					,_Fld24961 [ПФРНаДоплатуКПенсииШахтерам]
					From _Document23165(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РасчетыПоСтраховымВзносам();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РасчетыПоСтраховымВзносам();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.ДатаПлатежа = Читалка.GetDateTime(7);
							Ссылка.МесяцРасчетногоПериода = Читалка.GetDateTime(8);
							Ссылка.ПФРСтраховая = Читалка.GetDecimal(9);
							Ссылка.ПФРНакопительная = Читалка.GetDecimal(10);
							Ссылка.ФСС = Читалка.GetDecimal(11);
							Ссылка.ФФОМС = Читалка.GetDecimal(12);
							Ссылка.ТФОМС = Читалка.GetDecimal(13);
							Ссылка.ФССНесчастныеСлучаи = Читалка.GetDecimal(14);
							Ссылка.ПФРПоДополнительномуТарифу = Читалка.GetDecimal(15);
							Ссылка.ПлатежноеПоручениеФССНомер = Читалка.GetString(16);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗНомер = Читалка.GetString(17);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка.Получить((byte[])Читалка.GetValue(18));
							Ссылка.ПлатежноеПоручениеФССДата = Читалка.GetDateTime(19);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗДата = Читалка.GetDateTime(20);
							Ссылка.ФССЕНВД = Читалка.GetDecimal(21);
							Ссылка.ПФРНаДоплатуКПенсииШахтерам = Читалка.GetDecimal(22);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РасчетыПоСтраховымВзносам СтраницаПоСсылке(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld24942RRef [Организация]
					,_Fld24943 [Комментарий]
					,_Fld24944RRef [Ответственный]
					,_Fld24945RRef [ВидПлатежа]
					,_Fld24946 [ДатаПлатежа]
					,_Fld24947 [МесяцРасчетногоПериода]
					,_Fld24948 [ПФРСтраховая]
					,_Fld24949 [ПФРНакопительная]
					,_Fld24950 [ФСС]
					,_Fld24951 [ФФОМС]
					,_Fld24952 [ТФОМС]
					,_Fld24953 [ФССНесчастныеСлучаи]
					,_Fld24954 [ПФРПоДополнительномуТарифу]
					,_Fld24955 [ПлатежноеПоручениеФССНомер]
					,_Fld24956 [ПлатежноеПоручениеФСС_НС_ПЗНомер]
					,_Fld24957RRef [ВидОперации]
					,_Fld24958 [ПлатежноеПоручениеФССДата]
					,_Fld24959 [ПлатежноеПоручениеФСС_НС_ПЗДата]
					,_Fld24960 [ФССЕНВД]
					,_Fld24961 [ПФРНаДоплатуКПенсииШахтерам]
					From _Document23165(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РасчетыПоСтраховымВзносам();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РасчетыПоСтраховымВзносам();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.ДатаПлатежа = Читалка.GetDateTime(7);
							Ссылка.МесяцРасчетногоПериода = Читалка.GetDateTime(8);
							Ссылка.ПФРСтраховая = Читалка.GetDecimal(9);
							Ссылка.ПФРНакопительная = Читалка.GetDecimal(10);
							Ссылка.ФСС = Читалка.GetDecimal(11);
							Ссылка.ФФОМС = Читалка.GetDecimal(12);
							Ссылка.ТФОМС = Читалка.GetDecimal(13);
							Ссылка.ФССНесчастныеСлучаи = Читалка.GetDecimal(14);
							Ссылка.ПФРПоДополнительномуТарифу = Читалка.GetDecimal(15);
							Ссылка.ПлатежноеПоручениеФССНомер = Читалка.GetString(16);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗНомер = Читалка.GetString(17);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка.Получить((byte[])Читалка.GetValue(18));
							Ссылка.ПлатежноеПоручениеФССДата = Читалка.GetDateTime(19);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗДата = Читалка.GetDateTime(20);
							Ссылка.ФССЕНВД = Читалка.GetDecimal(21);
							Ссылка.ПФРНаДоплатуКПенсииШахтерам = Читалка.GetDecimal(22);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РасчетыПоСтраховымВзносам СтраницаПоНомеру(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld24942RRef [Организация]
					,_Fld24943 [Комментарий]
					,_Fld24944RRef [Ответственный]
					,_Fld24945RRef [ВидПлатежа]
					,_Fld24946 [ДатаПлатежа]
					,_Fld24947 [МесяцРасчетногоПериода]
					,_Fld24948 [ПФРСтраховая]
					,_Fld24949 [ПФРНакопительная]
					,_Fld24950 [ФСС]
					,_Fld24951 [ФФОМС]
					,_Fld24952 [ТФОМС]
					,_Fld24953 [ФССНесчастныеСлучаи]
					,_Fld24954 [ПФРПоДополнительномуТарифу]
					,_Fld24955 [ПлатежноеПоручениеФССНомер]
					,_Fld24956 [ПлатежноеПоручениеФСС_НС_ПЗНомер]
					,_Fld24957RRef [ВидОперации]
					,_Fld24958 [ПлатежноеПоручениеФССДата]
					,_Fld24959 [ПлатежноеПоручениеФСС_НС_ПЗДата]
					,_Fld24960 [ФССЕНВД]
					,_Fld24961 [ПФРНаДоплатуКПенсииШахтерам]
					From _Document23165(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РасчетыПоСтраховымВзносам();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РасчетыПоСтраховымВзносам();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.ДатаПлатежа = Читалка.GetDateTime(7);
							Ссылка.МесяцРасчетногоПериода = Читалка.GetDateTime(8);
							Ссылка.ПФРСтраховая = Читалка.GetDecimal(9);
							Ссылка.ПФРНакопительная = Читалка.GetDecimal(10);
							Ссылка.ФСС = Читалка.GetDecimal(11);
							Ссылка.ФФОМС = Читалка.GetDecimal(12);
							Ссылка.ТФОМС = Читалка.GetDecimal(13);
							Ссылка.ФССНесчастныеСлучаи = Читалка.GetDecimal(14);
							Ссылка.ПФРПоДополнительномуТарифу = Читалка.GetDecimal(15);
							Ссылка.ПлатежноеПоручениеФССНомер = Читалка.GetString(16);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗНомер = Читалка.GetString(17);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка.Получить((byte[])Читалка.GetValue(18));
							Ссылка.ПлатежноеПоручениеФССДата = Читалка.GetDateTime(19);
							Ссылка.ПлатежноеПоручениеФСС_НС_ПЗДата = Читалка.GetDateTime(20);
							Ссылка.ФССЕНВД = Читалка.GetDecimal(21);
							Ссылка.ПФРНаДоплатуКПенсииШахтерам = Читалка.GetDecimal(22);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.РасчетыПоСтраховымВзносам СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.РасчетыПоСтраховымВзносам();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.ПлатежноеПоручениеФССНомер = "";
			Объект.ПлатежноеПоручениеФСС_НС_ПЗНомер = "";
			Объект.ВидПлатежа = V82.Перечисления/*Ссылка*/.ВидыПлатежейВГосБюджет.ПустаяСсылка;
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРасчетыПоСтраховымВзносам.ПустаяСсылка;
			return Объект;
		}
	}
}