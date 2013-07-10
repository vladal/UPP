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
	public partial class РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль:ДокументМенеджер
	{
		
		public static ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld11277RRef [Организация]
					,_Fld11278 [НормированиеРасходовНаРекламу]
					,_Fld11279 [НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов]
					,_Fld11280 [НормированиеПредставительскихРасходов]
					,_Fld11281 [ЗакрытиеСчетовКосвенныхРасходов]
					,_Fld11283 [РаспределениеРасходовПоВидамДеятельности]
					,_Fld11284 [ПериодРегистрации]
					,_Fld11285RRef [Ответственный]
					,_Fld11286 [Комментарий]
					From _Document442(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НормированиеРасходовНаРекламу = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.НормированиеПредставительскихРасходов = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ЗакрытиеСчетовКосвенныхРасходов = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.РаспределениеРасходовПоВидамДеятельности = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Ссылка.Комментарий = Читалка.GetString(11);
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
		
		public static ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль НайтиПоНомеру(string Номер)
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
					,_Fld11277RRef [Организация]
					,_Fld11278 [НормированиеРасходовНаРекламу]
					,_Fld11279 [НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов]
					,_Fld11280 [НормированиеПредставительскихРасходов]
					,_Fld11281 [ЗакрытиеСчетовКосвенныхРасходов]
					,_Fld11283 [РаспределениеРасходовПоВидамДеятельности]
					,_Fld11284 [ПериодРегистрации]
					,_Fld11285RRef [Ответственный]
					,_Fld11286 [Комментарий]
					From _Document442(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НормированиеРасходовНаРекламу = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.НормированиеПредставительскихРасходов = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ЗакрытиеСчетовКосвенныхРасходов = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.РаспределениеРасходовПоВидамДеятельности = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Ссылка.Комментарий = Читалка.GetString(11);
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
		
		public static ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль Выбрать()
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
					,_Fld11277RRef [Организация]
					,_Fld11278 [НормированиеРасходовНаРекламу]
					,_Fld11279 [НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов]
					,_Fld11280 [НормированиеПредставительскихРасходов]
					,_Fld11281 [ЗакрытиеСчетовКосвенныхРасходов]
					,_Fld11283 [РаспределениеРасходовПоВидамДеятельности]
					,_Fld11284 [ПериодРегистрации]
					,_Fld11285RRef [Ответственный]
					,_Fld11286 [Комментарий]
					From _Document442(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НормированиеРасходовНаРекламу = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.НормированиеПредставительскихРасходов = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ЗакрытиеСчетовКосвенныхРасходов = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.РаспределениеРасходовПоВидамДеятельности = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Ссылка.Комментарий = Читалка.GetString(11);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld11277RRef [Организация]
					,_Fld11278 [НормированиеРасходовНаРекламу]
					,_Fld11279 [НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов]
					,_Fld11280 [НормированиеПредставительскихРасходов]
					,_Fld11281 [ЗакрытиеСчетовКосвенныхРасходов]
					,_Fld11283 [РаспределениеРасходовПоВидамДеятельности]
					,_Fld11284 [ПериодРегистрации]
					,_Fld11285RRef [Ответственный]
					,_Fld11286 [Комментарий]
					From _Document442(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НормированиеРасходовНаРекламу = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.НормированиеПредставительскихРасходов = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ЗакрытиеСчетовКосвенныхРасходов = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.РаспределениеРасходовПоВидамДеятельности = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Ссылка.Комментарий = Читалка.GetString(11);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld11277RRef [Организация]
					,_Fld11278 [НормированиеРасходовНаРекламу]
					,_Fld11279 [НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов]
					,_Fld11280 [НормированиеПредставительскихРасходов]
					,_Fld11281 [ЗакрытиеСчетовКосвенныхРасходов]
					,_Fld11283 [РаспределениеРасходовПоВидамДеятельности]
					,_Fld11284 [ПериодРегистрации]
					,_Fld11285RRef [Ответственный]
					,_Fld11286 [Комментарий]
					From _Document442(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НормированиеРасходовНаРекламу = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.НормированиеПредставительскихРасходов = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ЗакрытиеСчетовКосвенныхРасходов = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.РаспределениеРасходовПоВидамДеятельности = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Ссылка.Комментарий = Читалка.GetString(11);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld11277RRef [Организация]
					,_Fld11278 [НормированиеРасходовНаРекламу]
					,_Fld11279 [НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов]
					,_Fld11280 [НормированиеПредставительскихРасходов]
					,_Fld11281 [ЗакрытиеСчетовКосвенныхРасходов]
					,_Fld11283 [РаспределениеРасходовПоВидамДеятельности]
					,_Fld11284 [ПериодРегистрации]
					,_Fld11285RRef [Ответственный]
					,_Fld11286 [Комментарий]
					From _Document442(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НормированиеРасходовНаРекламу = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.НормированиеПредставительскихРасходов = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ЗакрытиеСчетовКосвенныхРасходов = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.РаспределениеРасходовПоВидамДеятельности = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Ссылка.Комментарий = Читалка.GetString(11);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld11277RRef [Организация]
					,_Fld11278 [НормированиеРасходовНаРекламу]
					,_Fld11279 [НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов]
					,_Fld11280 [НормированиеПредставительскихРасходов]
					,_Fld11281 [ЗакрытиеСчетовКосвенныхРасходов]
					,_Fld11283 [РаспределениеРасходовПоВидамДеятельности]
					,_Fld11284 [ПериодРегистрации]
					,_Fld11285RRef [Ответственный]
					,_Fld11286 [Комментарий]
					From _Document442(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НормированиеРасходовНаРекламу = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.НормированиеРасходовНаДобровольноеСтрахованиеИВозмещениеПроцентов = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.НормированиеПредставительскихРасходов = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ЗакрытиеСчетовКосвенныхРасходов = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.РаспределениеРасходовПоВидамДеятельности = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Ссылка.Комментарий = Читалка.GetString(11);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.РегламентныеОперацииНалоговогоУчетаПоНалогуНаПрибыль();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			return Объект;
		}
	}
}