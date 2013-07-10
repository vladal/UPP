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
	public partial class НачислениеЗарплатыРаботникамОрганизаций:ДокументМенеджер
	{
		
		public static ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld6212 [ПериодРегистрации]
					,_Fld6213RRef [Организация]
					,_Fld6214RRef [ПодразделениеОрганизации]
					,_Fld6215 [Комментарий]
					,_Fld6216RRef [Ответственный]
					,_Fld6217 [КраткийСоставДокумента]
					,_Fld6218_TYPE [ПерерассчитываемыйДокумент_Тип],_Fld6218_RRRef [ПерерассчитываемыйДокумент],_Fld6218_RTRef [ПерерассчитываемыйДокумент_Вид]
					,_Fld6219RRef [ВидОперации]
					,_Fld21540RRef [ПериодНачисления]
					,_Fld21541 [ПериодНачисленияДатаНачала]
					,_Fld21542 [ПериодНачисленияДатаОкончания]
					From _Document320(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(3);
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							Ссылка.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(13));
							Ссылка.ПериодНачисленияДатаНачала = Читалка.GetDateTime(14);
							Ссылка.ПериодНачисленияДатаОкончания = Читалка.GetDateTime(15);
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
		
		public static ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций НайтиПоНомеру(string Номер)
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
					,_Fld6212 [ПериодРегистрации]
					,_Fld6213RRef [Организация]
					,_Fld6214RRef [ПодразделениеОрганизации]
					,_Fld6215 [Комментарий]
					,_Fld6216RRef [Ответственный]
					,_Fld6217 [КраткийСоставДокумента]
					,_Fld6218_TYPE [ПерерассчитываемыйДокумент_Тип],_Fld6218_RRRef [ПерерассчитываемыйДокумент],_Fld6218_RTRef [ПерерассчитываемыйДокумент_Вид]
					,_Fld6219RRef [ВидОперации]
					,_Fld21540RRef [ПериодНачисления]
					,_Fld21541 [ПериодНачисленияДатаНачала]
					,_Fld21542 [ПериодНачисленияДатаОкончания]
					From _Document320(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(3);
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							Ссылка.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(13));
							Ссылка.ПериодНачисленияДатаНачала = Читалка.GetDateTime(14);
							Ссылка.ПериодНачисленияДатаОкончания = Читалка.GetDateTime(15);
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
		
		public static ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций Выбрать()
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
					,_Fld6212 [ПериодРегистрации]
					,_Fld6213RRef [Организация]
					,_Fld6214RRef [ПодразделениеОрганизации]
					,_Fld6215 [Комментарий]
					,_Fld6216RRef [Ответственный]
					,_Fld6217 [КраткийСоставДокумента]
					,_Fld6218_TYPE [ПерерассчитываемыйДокумент_Тип],_Fld6218_RRRef [ПерерассчитываемыйДокумент],_Fld6218_RTRef [ПерерассчитываемыйДокумент_Вид]
					,_Fld6219RRef [ВидОперации]
					,_Fld21540RRef [ПериодНачисления]
					,_Fld21541 [ПериодНачисленияДатаНачала]
					,_Fld21542 [ПериодНачисленияДатаОкончания]
					From _Document320(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(3);
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							Ссылка.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(13));
							Ссылка.ПериодНачисленияДатаНачала = Читалка.GetDateTime(14);
							Ссылка.ПериодНачисленияДатаОкончания = Читалка.GetDateTime(15);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld6212 [ПериодРегистрации]
					,_Fld6213RRef [Организация]
					,_Fld6214RRef [ПодразделениеОрганизации]
					,_Fld6215 [Комментарий]
					,_Fld6216RRef [Ответственный]
					,_Fld6217 [КраткийСоставДокумента]
					,_Fld6218_TYPE [ПерерассчитываемыйДокумент_Тип],_Fld6218_RRRef [ПерерассчитываемыйДокумент],_Fld6218_RTRef [ПерерассчитываемыйДокумент_Вид]
					,_Fld6219RRef [ВидОперации]
					,_Fld21540RRef [ПериодНачисления]
					,_Fld21541 [ПериодНачисленияДатаНачала]
					,_Fld21542 [ПериодНачисленияДатаОкончания]
					From _Document320(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(3);
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							Ссылка.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(13));
							Ссылка.ПериодНачисленияДатаНачала = Читалка.GetDateTime(14);
							Ссылка.ПериодНачисленияДатаОкончания = Читалка.GetDateTime(15);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld6212 [ПериодРегистрации]
					,_Fld6213RRef [Организация]
					,_Fld6214RRef [ПодразделениеОрганизации]
					,_Fld6215 [Комментарий]
					,_Fld6216RRef [Ответственный]
					,_Fld6217 [КраткийСоставДокумента]
					,_Fld6218_TYPE [ПерерассчитываемыйДокумент_Тип],_Fld6218_RRRef [ПерерассчитываемыйДокумент],_Fld6218_RTRef [ПерерассчитываемыйДокумент_Вид]
					,_Fld6219RRef [ВидОперации]
					,_Fld21540RRef [ПериодНачисления]
					,_Fld21541 [ПериодНачисленияДатаНачала]
					,_Fld21542 [ПериодНачисленияДатаОкончания]
					From _Document320(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(3);
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							Ссылка.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(13));
							Ссылка.ПериодНачисленияДатаНачала = Читалка.GetDateTime(14);
							Ссылка.ПериодНачисленияДатаОкончания = Читалка.GetDateTime(15);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld6212 [ПериодРегистрации]
					,_Fld6213RRef [Организация]
					,_Fld6214RRef [ПодразделениеОрганизации]
					,_Fld6215 [Комментарий]
					,_Fld6216RRef [Ответственный]
					,_Fld6217 [КраткийСоставДокумента]
					,_Fld6218_TYPE [ПерерассчитываемыйДокумент_Тип],_Fld6218_RRRef [ПерерассчитываемыйДокумент],_Fld6218_RTRef [ПерерассчитываемыйДокумент_Вид]
					,_Fld6219RRef [ВидОперации]
					,_Fld21540RRef [ПериодНачисления]
					,_Fld21541 [ПериодНачисленияДатаНачала]
					,_Fld21542 [ПериодНачисленияДатаОкончания]
					From _Document320(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(3);
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							Ссылка.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(13));
							Ссылка.ПериодНачисленияДатаНачала = Читалка.GetDateTime(14);
							Ссылка.ПериодНачисленияДатаОкончания = Читалка.GetDateTime(15);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld6212 [ПериодРегистрации]
					,_Fld6213RRef [Организация]
					,_Fld6214RRef [ПодразделениеОрганизации]
					,_Fld6215 [Комментарий]
					,_Fld6216RRef [Ответственный]
					,_Fld6217 [КраткийСоставДокумента]
					,_Fld6218_TYPE [ПерерассчитываемыйДокумент_Тип],_Fld6218_RRRef [ПерерассчитываемыйДокумент],_Fld6218_RTRef [ПерерассчитываемыйДокумент_Вид]
					,_Fld6219RRef [ВидОперации]
					,_Fld21540RRef [ПериодНачисления]
					,_Fld21541 [ПериодНачисленияДатаНачала]
					,_Fld21542 [ПериодНачисленияДатаОкончания]
					From _Document320(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.НачислениеЗарплатыРаботникамОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(3);
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							Ссылка.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(13));
							Ссылка.ПериодНачисленияДатаНачала = Читалка.GetDateTime(14);
							Ссылка.ПериодНачисленияДатаОкончания = Читалка.GetDateTime(15);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.НачислениеЗарплатыРаботникамОрганизаций СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.НачислениеЗарплатыРаботникамОрганизаций();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.КраткийСоставДокумента = "";
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийНачислениеЗарплатыРаботникамОрганизаций.ПустаяСсылка;
			Объект.ПериодНачисления = V82.Перечисления/*Ссылка*/.ПериодНачисленияЗарплаты.ПустаяСсылка;
			return Объект;
		}
	}
}