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
	///(Общ)
	///</summary>
	public partial class ИнкассовоеПоручениеПолученное:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ИнкассовоеПоручениеПолученное НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld5273_TYPE [ДокументОснование_Тип],_Fld5273_RRRef [ДокументОснование],_Fld5273_RTRef [ДокументОснование_Вид]
					,_Fld5274 [НомерВходящегоДокумента]
					,_Fld5275 [ДатаВходящегоДокумента]
					,_Fld5276RRef [Организация]
					,_Fld5277RRef [СчетОрганизации]
					,_Fld5278RRef [Контрагент]
					,_Fld5279RRef [СчетКонтрагента]
					,_Fld5280 [ВидПлатежа]
					,_Fld5281 [ОчередностьПлатежа]
					,_Fld5282 [НазначениеПлатежа]
					,_Fld5283 [СуммаДокумента]
					,_Fld5284RRef [ВалютаДокумента]
					,_Fld5285RRef [ДоговорКонтрагента]
					,_Fld5286 [ОтраженоВОперУчете]
					,_Fld5287 [Оплачено]
					,_Fld5288 [ДатаОплаты]
					,_Fld5289 [Комментарий]
					,_Fld5290RRef [Ответственный]
					,_Fld5291RRef [ВидОперации]
					,_Fld5292 [ОтражатьВБухгалтерскомУчете]
					,_Fld5293RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld5294RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld5295RRef [СубконтоДт1]
					,_Fld5296RRef [СубконтоДт2]
					,_Fld5297RRef [СубконтоДт3]
					,_Fld5298 [ЧастичнаяОплата]
					,_Fld5299 [ОтражатьВНалоговомУчете]
					,_Fld5300 [Содержание_УСН]
					,_Fld5301 [Графа4_УСН]
					,_Fld5302 [Графа5_УСН]
					,_Fld5303 [Графа6_УСН]
					,_Fld5304 [Графа7_УСН]
					,_Fld5305 [ДоходыЕНВД_УСН]
					,_Fld5306 [РасходыЕНВД_УСН]
					,_Fld5307 [НДС_УСН]
					,_Fld5308 [РучнаяНастройка_УСН]
					,_Fld5309RRef [Подразделение]
					,_Fld26784RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld26785RRef [СубконтоНУДт1]
					,_Fld26786RRef [СубконтоНУДт2]
					,_Fld26787RRef [СубконтоНУДт3]
					From _Document293(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнкассовоеПоручениеПолученное();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(6);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(7);
							Ссылка.ВидПлатежа = Читалка.GetString(12);
							Ссылка.ОчередностьПлатежа = Читалка.GetDecimal(13);
							Ссылка.НазначениеПлатежа = Читалка.GetString(14);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(15);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ДатаОплаты = Читалка.GetDateTime(20);
							Ссылка.Комментарий = Читалка.GetString(21);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(24))[0]==1;
							Ссылка.ЧастичнаяОплата = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(31))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(32);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(33);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(36);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(37))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(38))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(39);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(40))[0]==1;
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
		
		public static ДокументыСсылка.ИнкассовоеПоручениеПолученное НайтиПоНомеру(string Номер)
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
					,_Fld5273_TYPE [ДокументОснование_Тип],_Fld5273_RRRef [ДокументОснование],_Fld5273_RTRef [ДокументОснование_Вид]
					,_Fld5274 [НомерВходящегоДокумента]
					,_Fld5275 [ДатаВходящегоДокумента]
					,_Fld5276RRef [Организация]
					,_Fld5277RRef [СчетОрганизации]
					,_Fld5278RRef [Контрагент]
					,_Fld5279RRef [СчетКонтрагента]
					,_Fld5280 [ВидПлатежа]
					,_Fld5281 [ОчередностьПлатежа]
					,_Fld5282 [НазначениеПлатежа]
					,_Fld5283 [СуммаДокумента]
					,_Fld5284RRef [ВалютаДокумента]
					,_Fld5285RRef [ДоговорКонтрагента]
					,_Fld5286 [ОтраженоВОперУчете]
					,_Fld5287 [Оплачено]
					,_Fld5288 [ДатаОплаты]
					,_Fld5289 [Комментарий]
					,_Fld5290RRef [Ответственный]
					,_Fld5291RRef [ВидОперации]
					,_Fld5292 [ОтражатьВБухгалтерскомУчете]
					,_Fld5293RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld5294RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld5295RRef [СубконтоДт1]
					,_Fld5296RRef [СубконтоДт2]
					,_Fld5297RRef [СубконтоДт3]
					,_Fld5298 [ЧастичнаяОплата]
					,_Fld5299 [ОтражатьВНалоговомУчете]
					,_Fld5300 [Содержание_УСН]
					,_Fld5301 [Графа4_УСН]
					,_Fld5302 [Графа5_УСН]
					,_Fld5303 [Графа6_УСН]
					,_Fld5304 [Графа7_УСН]
					,_Fld5305 [ДоходыЕНВД_УСН]
					,_Fld5306 [РасходыЕНВД_УСН]
					,_Fld5307 [НДС_УСН]
					,_Fld5308 [РучнаяНастройка_УСН]
					,_Fld5309RRef [Подразделение]
					,_Fld26784RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld26785RRef [СубконтоНУДт1]
					,_Fld26786RRef [СубконтоНУДт2]
					,_Fld26787RRef [СубконтоНУДт3]
					From _Document293(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнкассовоеПоручениеПолученное();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(6);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(7);
							Ссылка.ВидПлатежа = Читалка.GetString(12);
							Ссылка.ОчередностьПлатежа = Читалка.GetDecimal(13);
							Ссылка.НазначениеПлатежа = Читалка.GetString(14);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(15);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ДатаОплаты = Читалка.GetDateTime(20);
							Ссылка.Комментарий = Читалка.GetString(21);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(24))[0]==1;
							Ссылка.ЧастичнаяОплата = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(31))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(32);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(33);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(36);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(37))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(38))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(39);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(40))[0]==1;
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
		
		public static ДокументыВыборка.ИнкассовоеПоручениеПолученное Выбрать()
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
					,_Fld5273_TYPE [ДокументОснование_Тип],_Fld5273_RRRef [ДокументОснование],_Fld5273_RTRef [ДокументОснование_Вид]
					,_Fld5274 [НомерВходящегоДокумента]
					,_Fld5275 [ДатаВходящегоДокумента]
					,_Fld5276RRef [Организация]
					,_Fld5277RRef [СчетОрганизации]
					,_Fld5278RRef [Контрагент]
					,_Fld5279RRef [СчетКонтрагента]
					,_Fld5280 [ВидПлатежа]
					,_Fld5281 [ОчередностьПлатежа]
					,_Fld5282 [НазначениеПлатежа]
					,_Fld5283 [СуммаДокумента]
					,_Fld5284RRef [ВалютаДокумента]
					,_Fld5285RRef [ДоговорКонтрагента]
					,_Fld5286 [ОтраженоВОперУчете]
					,_Fld5287 [Оплачено]
					,_Fld5288 [ДатаОплаты]
					,_Fld5289 [Комментарий]
					,_Fld5290RRef [Ответственный]
					,_Fld5291RRef [ВидОперации]
					,_Fld5292 [ОтражатьВБухгалтерскомУчете]
					,_Fld5293RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld5294RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld5295RRef [СубконтоДт1]
					,_Fld5296RRef [СубконтоДт2]
					,_Fld5297RRef [СубконтоДт3]
					,_Fld5298 [ЧастичнаяОплата]
					,_Fld5299 [ОтражатьВНалоговомУчете]
					,_Fld5300 [Содержание_УСН]
					,_Fld5301 [Графа4_УСН]
					,_Fld5302 [Графа5_УСН]
					,_Fld5303 [Графа6_УСН]
					,_Fld5304 [Графа7_УСН]
					,_Fld5305 [ДоходыЕНВД_УСН]
					,_Fld5306 [РасходыЕНВД_УСН]
					,_Fld5307 [НДС_УСН]
					,_Fld5308 [РучнаяНастройка_УСН]
					,_Fld5309RRef [Подразделение]
					,_Fld26784RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld26785RRef [СубконтоНУДт1]
					,_Fld26786RRef [СубконтоНУДт2]
					,_Fld26787RRef [СубконтоНУДт3]
					From _Document293(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ИнкассовоеПоручениеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнкассовоеПоручениеПолученное();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(6);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(7);
							Ссылка.ВидПлатежа = Читалка.GetString(12);
							Ссылка.ОчередностьПлатежа = Читалка.GetDecimal(13);
							Ссылка.НазначениеПлатежа = Читалка.GetString(14);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(15);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ДатаОплаты = Читалка.GetDateTime(20);
							Ссылка.Комментарий = Читалка.GetString(21);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(24))[0]==1;
							Ссылка.ЧастичнаяОплата = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(31))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(32);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(33);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(36);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(37))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(38))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(39);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(40))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнкассовоеПоручениеПолученное ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld5273_TYPE [ДокументОснование_Тип],_Fld5273_RRRef [ДокументОснование],_Fld5273_RTRef [ДокументОснование_Вид]
					,_Fld5274 [НомерВходящегоДокумента]
					,_Fld5275 [ДатаВходящегоДокумента]
					,_Fld5276RRef [Организация]
					,_Fld5277RRef [СчетОрганизации]
					,_Fld5278RRef [Контрагент]
					,_Fld5279RRef [СчетКонтрагента]
					,_Fld5280 [ВидПлатежа]
					,_Fld5281 [ОчередностьПлатежа]
					,_Fld5282 [НазначениеПлатежа]
					,_Fld5283 [СуммаДокумента]
					,_Fld5284RRef [ВалютаДокумента]
					,_Fld5285RRef [ДоговорКонтрагента]
					,_Fld5286 [ОтраженоВОперУчете]
					,_Fld5287 [Оплачено]
					,_Fld5288 [ДатаОплаты]
					,_Fld5289 [Комментарий]
					,_Fld5290RRef [Ответственный]
					,_Fld5291RRef [ВидОперации]
					,_Fld5292 [ОтражатьВБухгалтерскомУчете]
					,_Fld5293RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld5294RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld5295RRef [СубконтоДт1]
					,_Fld5296RRef [СубконтоДт2]
					,_Fld5297RRef [СубконтоДт3]
					,_Fld5298 [ЧастичнаяОплата]
					,_Fld5299 [ОтражатьВНалоговомУчете]
					,_Fld5300 [Содержание_УСН]
					,_Fld5301 [Графа4_УСН]
					,_Fld5302 [Графа5_УСН]
					,_Fld5303 [Графа6_УСН]
					,_Fld5304 [Графа7_УСН]
					,_Fld5305 [ДоходыЕНВД_УСН]
					,_Fld5306 [РасходыЕНВД_УСН]
					,_Fld5307 [НДС_УСН]
					,_Fld5308 [РучнаяНастройка_УСН]
					,_Fld5309RRef [Подразделение]
					,_Fld26784RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld26785RRef [СубконтоНУДт1]
					,_Fld26786RRef [СубконтоНУДт2]
					,_Fld26787RRef [СубконтоНУДт3]
					From _Document293(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ИнкассовоеПоручениеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнкассовоеПоручениеПолученное();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(6);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(7);
							Ссылка.ВидПлатежа = Читалка.GetString(12);
							Ссылка.ОчередностьПлатежа = Читалка.GetDecimal(13);
							Ссылка.НазначениеПлатежа = Читалка.GetString(14);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(15);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ДатаОплаты = Читалка.GetDateTime(20);
							Ссылка.Комментарий = Читалка.GetString(21);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(24))[0]==1;
							Ссылка.ЧастичнаяОплата = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(31))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(32);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(33);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(36);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(37))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(38))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(39);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(40))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнкассовоеПоручениеПолученное ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld5273_TYPE [ДокументОснование_Тип],_Fld5273_RRRef [ДокументОснование],_Fld5273_RTRef [ДокументОснование_Вид]
					,_Fld5274 [НомерВходящегоДокумента]
					,_Fld5275 [ДатаВходящегоДокумента]
					,_Fld5276RRef [Организация]
					,_Fld5277RRef [СчетОрганизации]
					,_Fld5278RRef [Контрагент]
					,_Fld5279RRef [СчетКонтрагента]
					,_Fld5280 [ВидПлатежа]
					,_Fld5281 [ОчередностьПлатежа]
					,_Fld5282 [НазначениеПлатежа]
					,_Fld5283 [СуммаДокумента]
					,_Fld5284RRef [ВалютаДокумента]
					,_Fld5285RRef [ДоговорКонтрагента]
					,_Fld5286 [ОтраженоВОперУчете]
					,_Fld5287 [Оплачено]
					,_Fld5288 [ДатаОплаты]
					,_Fld5289 [Комментарий]
					,_Fld5290RRef [Ответственный]
					,_Fld5291RRef [ВидОперации]
					,_Fld5292 [ОтражатьВБухгалтерскомУчете]
					,_Fld5293RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld5294RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld5295RRef [СубконтоДт1]
					,_Fld5296RRef [СубконтоДт2]
					,_Fld5297RRef [СубконтоДт3]
					,_Fld5298 [ЧастичнаяОплата]
					,_Fld5299 [ОтражатьВНалоговомУчете]
					,_Fld5300 [Содержание_УСН]
					,_Fld5301 [Графа4_УСН]
					,_Fld5302 [Графа5_УСН]
					,_Fld5303 [Графа6_УСН]
					,_Fld5304 [Графа7_УСН]
					,_Fld5305 [ДоходыЕНВД_УСН]
					,_Fld5306 [РасходыЕНВД_УСН]
					,_Fld5307 [НДС_УСН]
					,_Fld5308 [РучнаяНастройка_УСН]
					,_Fld5309RRef [Подразделение]
					,_Fld26784RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld26785RRef [СубконтоНУДт1]
					,_Fld26786RRef [СубконтоНУДт2]
					,_Fld26787RRef [СубконтоНУДт3]
					From _Document293(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ИнкассовоеПоручениеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнкассовоеПоручениеПолученное();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(6);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(7);
							Ссылка.ВидПлатежа = Читалка.GetString(12);
							Ссылка.ОчередностьПлатежа = Читалка.GetDecimal(13);
							Ссылка.НазначениеПлатежа = Читалка.GetString(14);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(15);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ДатаОплаты = Читалка.GetDateTime(20);
							Ссылка.Комментарий = Читалка.GetString(21);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(24))[0]==1;
							Ссылка.ЧастичнаяОплата = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(31))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(32);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(33);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(36);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(37))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(38))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(39);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(40))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнкассовоеПоручениеПолученное СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld5273_TYPE [ДокументОснование_Тип],_Fld5273_RRRef [ДокументОснование],_Fld5273_RTRef [ДокументОснование_Вид]
					,_Fld5274 [НомерВходящегоДокумента]
					,_Fld5275 [ДатаВходящегоДокумента]
					,_Fld5276RRef [Организация]
					,_Fld5277RRef [СчетОрганизации]
					,_Fld5278RRef [Контрагент]
					,_Fld5279RRef [СчетКонтрагента]
					,_Fld5280 [ВидПлатежа]
					,_Fld5281 [ОчередностьПлатежа]
					,_Fld5282 [НазначениеПлатежа]
					,_Fld5283 [СуммаДокумента]
					,_Fld5284RRef [ВалютаДокумента]
					,_Fld5285RRef [ДоговорКонтрагента]
					,_Fld5286 [ОтраженоВОперУчете]
					,_Fld5287 [Оплачено]
					,_Fld5288 [ДатаОплаты]
					,_Fld5289 [Комментарий]
					,_Fld5290RRef [Ответственный]
					,_Fld5291RRef [ВидОперации]
					,_Fld5292 [ОтражатьВБухгалтерскомУчете]
					,_Fld5293RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld5294RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld5295RRef [СубконтоДт1]
					,_Fld5296RRef [СубконтоДт2]
					,_Fld5297RRef [СубконтоДт3]
					,_Fld5298 [ЧастичнаяОплата]
					,_Fld5299 [ОтражатьВНалоговомУчете]
					,_Fld5300 [Содержание_УСН]
					,_Fld5301 [Графа4_УСН]
					,_Fld5302 [Графа5_УСН]
					,_Fld5303 [Графа6_УСН]
					,_Fld5304 [Графа7_УСН]
					,_Fld5305 [ДоходыЕНВД_УСН]
					,_Fld5306 [РасходыЕНВД_УСН]
					,_Fld5307 [НДС_УСН]
					,_Fld5308 [РучнаяНастройка_УСН]
					,_Fld5309RRef [Подразделение]
					,_Fld26784RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld26785RRef [СубконтоНУДт1]
					,_Fld26786RRef [СубконтоНУДт2]
					,_Fld26787RRef [СубконтоНУДт3]
					From _Document293(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ИнкассовоеПоручениеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнкассовоеПоручениеПолученное();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(6);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(7);
							Ссылка.ВидПлатежа = Читалка.GetString(12);
							Ссылка.ОчередностьПлатежа = Читалка.GetDecimal(13);
							Ссылка.НазначениеПлатежа = Читалка.GetString(14);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(15);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ДатаОплаты = Читалка.GetDateTime(20);
							Ссылка.Комментарий = Читалка.GetString(21);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(24))[0]==1;
							Ссылка.ЧастичнаяОплата = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(31))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(32);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(33);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(36);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(37))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(38))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(39);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(40))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнкассовоеПоручениеПолученное СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld5273_TYPE [ДокументОснование_Тип],_Fld5273_RRRef [ДокументОснование],_Fld5273_RTRef [ДокументОснование_Вид]
					,_Fld5274 [НомерВходящегоДокумента]
					,_Fld5275 [ДатаВходящегоДокумента]
					,_Fld5276RRef [Организация]
					,_Fld5277RRef [СчетОрганизации]
					,_Fld5278RRef [Контрагент]
					,_Fld5279RRef [СчетКонтрагента]
					,_Fld5280 [ВидПлатежа]
					,_Fld5281 [ОчередностьПлатежа]
					,_Fld5282 [НазначениеПлатежа]
					,_Fld5283 [СуммаДокумента]
					,_Fld5284RRef [ВалютаДокумента]
					,_Fld5285RRef [ДоговорКонтрагента]
					,_Fld5286 [ОтраженоВОперУчете]
					,_Fld5287 [Оплачено]
					,_Fld5288 [ДатаОплаты]
					,_Fld5289 [Комментарий]
					,_Fld5290RRef [Ответственный]
					,_Fld5291RRef [ВидОперации]
					,_Fld5292 [ОтражатьВБухгалтерскомУчете]
					,_Fld5293RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld5294RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld5295RRef [СубконтоДт1]
					,_Fld5296RRef [СубконтоДт2]
					,_Fld5297RRef [СубконтоДт3]
					,_Fld5298 [ЧастичнаяОплата]
					,_Fld5299 [ОтражатьВНалоговомУчете]
					,_Fld5300 [Содержание_УСН]
					,_Fld5301 [Графа4_УСН]
					,_Fld5302 [Графа5_УСН]
					,_Fld5303 [Графа6_УСН]
					,_Fld5304 [Графа7_УСН]
					,_Fld5305 [ДоходыЕНВД_УСН]
					,_Fld5306 [РасходыЕНВД_УСН]
					,_Fld5307 [НДС_УСН]
					,_Fld5308 [РучнаяНастройка_УСН]
					,_Fld5309RRef [Подразделение]
					,_Fld26784RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld26785RRef [СубконтоНУДт1]
					,_Fld26786RRef [СубконтоНУДт2]
					,_Fld26787RRef [СубконтоНУДт3]
					From _Document293(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ИнкассовоеПоручениеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнкассовоеПоручениеПолученное();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(6);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(7);
							Ссылка.ВидПлатежа = Читалка.GetString(12);
							Ссылка.ОчередностьПлатежа = Читалка.GetDecimal(13);
							Ссылка.НазначениеПлатежа = Читалка.GetString(14);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(15);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ДатаОплаты = Читалка.GetDateTime(20);
							Ссылка.Комментарий = Читалка.GetString(21);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(24))[0]==1;
							Ссылка.ЧастичнаяОплата = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(31))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(32);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(33);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(36);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(37))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(38))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(39);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(40))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ИнкассовоеПоручениеПолученное СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ИнкассовоеПоручениеПолученное();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.НомерВходящегоДокумента = "";
			Объект.ВидПлатежа = "";
			Объект.НазначениеПлатежа = "";
			Объект.Комментарий = "";
			Объект.Содержание_УСН = "";
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка;
			return Объект;
		}
	}
}