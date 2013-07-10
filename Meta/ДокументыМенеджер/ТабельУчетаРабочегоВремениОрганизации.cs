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
	public partial class ТабельУчетаРабочегоВремениОрганизации:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld20206RRef [Организация]
					,_Fld20207 [ПериодРегистрации]
					,_Fld20208RRef [ПодразделениеОрганизации]
					,_Fld20209RRef [Ответственный]
					,_Fld20210 [Комментарий]
					,_Fld20211 [КраткийСоставДокумента]
					,_Fld20212RRef [СпособВводаДанных]
					,_Fld20213RRef [СпособУказанияПериода]
					,_Fld20214 [ДатаНачалаПериода]
					,_Fld20215 [ДатаОкончанияПериода]
					From _Document19664(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Ссылка.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(11);
							Ссылка.ДатаОкончанияПериода = Читалка.GetDateTime(12);
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
		
		public static ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации НайтиПоНомеру(string Номер)
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
					,_Fld20206RRef [Организация]
					,_Fld20207 [ПериодРегистрации]
					,_Fld20208RRef [ПодразделениеОрганизации]
					,_Fld20209RRef [Ответственный]
					,_Fld20210 [Комментарий]
					,_Fld20211 [КраткийСоставДокумента]
					,_Fld20212RRef [СпособВводаДанных]
					,_Fld20213RRef [СпособУказанияПериода]
					,_Fld20214 [ДатаНачалаПериода]
					,_Fld20215 [ДатаОкончанияПериода]
					From _Document19664(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Ссылка.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(11);
							Ссылка.ДатаОкончанияПериода = Читалка.GetDateTime(12);
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
		
		public static ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации Выбрать()
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
					,_Fld20206RRef [Организация]
					,_Fld20207 [ПериодРегистрации]
					,_Fld20208RRef [ПодразделениеОрганизации]
					,_Fld20209RRef [Ответственный]
					,_Fld20210 [Комментарий]
					,_Fld20211 [КраткийСоставДокумента]
					,_Fld20212RRef [СпособВводаДанных]
					,_Fld20213RRef [СпособУказанияПериода]
					,_Fld20214 [ДатаНачалаПериода]
					,_Fld20215 [ДатаОкончанияПериода]
					From _Document19664(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Ссылка.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(11);
							Ссылка.ДатаОкончанияПериода = Читалка.GetDateTime(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld20206RRef [Организация]
					,_Fld20207 [ПериодРегистрации]
					,_Fld20208RRef [ПодразделениеОрганизации]
					,_Fld20209RRef [Ответственный]
					,_Fld20210 [Комментарий]
					,_Fld20211 [КраткийСоставДокумента]
					,_Fld20212RRef [СпособВводаДанных]
					,_Fld20213RRef [СпособУказанияПериода]
					,_Fld20214 [ДатаНачалаПериода]
					,_Fld20215 [ДатаОкончанияПериода]
					From _Document19664(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Ссылка.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(11);
							Ссылка.ДатаОкончанияПериода = Читалка.GetDateTime(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld20206RRef [Организация]
					,_Fld20207 [ПериодРегистрации]
					,_Fld20208RRef [ПодразделениеОрганизации]
					,_Fld20209RRef [Ответственный]
					,_Fld20210 [Комментарий]
					,_Fld20211 [КраткийСоставДокумента]
					,_Fld20212RRef [СпособВводаДанных]
					,_Fld20213RRef [СпособУказанияПериода]
					,_Fld20214 [ДатаНачалаПериода]
					,_Fld20215 [ДатаОкончанияПериода]
					From _Document19664(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Ссылка.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(11);
							Ссылка.ДатаОкончанияПериода = Читалка.GetDateTime(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld20206RRef [Организация]
					,_Fld20207 [ПериодРегистрации]
					,_Fld20208RRef [ПодразделениеОрганизации]
					,_Fld20209RRef [Ответственный]
					,_Fld20210 [Комментарий]
					,_Fld20211 [КраткийСоставДокумента]
					,_Fld20212RRef [СпособВводаДанных]
					,_Fld20213RRef [СпособУказанияПериода]
					,_Fld20214 [ДатаНачалаПериода]
					,_Fld20215 [ДатаОкончанияПериода]
					From _Document19664(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Ссылка.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(11);
							Ссылка.ДатаОкончанияПериода = Читалка.GetDateTime(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld20206RRef [Организация]
					,_Fld20207 [ПериодРегистрации]
					,_Fld20208RRef [ПодразделениеОрганизации]
					,_Fld20209RRef [Ответственный]
					,_Fld20210 [Комментарий]
					,_Fld20211 [КраткийСоставДокумента]
					,_Fld20212RRef [СпособВводаДанных]
					,_Fld20213RRef [СпособУказанияПериода]
					,_Fld20214 [ДатаНачалаПериода]
					,_Fld20215 [ДатаОкончанияПериода]
					From _Document19664(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ТабельУчетаРабочегоВремениОрганизации();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ТабельУчетаРабочегоВремениОрганизации();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Ссылка.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(11);
							Ссылка.ДатаОкончанияПериода = Читалка.GetDateTime(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ТабельУчетаРабочегоВремениОрганизации СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ТабельУчетаРабочегоВремениОрганизации();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.КраткийСоставДокумента = "";
			Объект.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка;
			Объект.СпособУказанияПериода = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка;
			return Объект;
		}
	}
}