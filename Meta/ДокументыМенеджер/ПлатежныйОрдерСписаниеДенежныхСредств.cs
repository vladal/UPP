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
	public partial class ПлатежныйОрдерСписаниеДенежныхСредств:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld8952_TYPE [РасчетныйДокумент_Тип],_Fld8952_RRRef [РасчетныйДокумент],_Fld8952_RTRef [РасчетныйДокумент_Вид]
					,_Fld8953_TYPE [ДокументОснование_Тип],_Fld8953_RRRef [ДокументОснование],_Fld8953_RTRef [ДокументОснование_Вид]
					,_Fld8954RRef [Организация]
					,_Fld8955RRef [СчетОрганизации]
					,_Fld8956RRef [Контрагент]
					,_Fld8957RRef [СчетКонтрагента]
					,_Fld18619 [НомерВходящегоДокумента]
					,_Fld18620 [ДатаВходящегоДокумента]
					,_Fld8958RRef [ДоговорКонтрагента]
					,_Fld8961 [ОтраженоВОперУчете]
					,_Fld8962 [Комментарий]
					,_Fld8960RRef [ВалютаДокумента]
					,_Fld8971 [Оплачено]
					,_Fld8965 [ОтражатьВБухгалтерскомУчете]
					,_Fld8963RRef [Ответственный]
					,_Fld8959 [СуммаДокумента]
					,_Fld8964RRef [ВидОперации]
					,_Fld8966RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8967RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8968RRef [СубконтоДт1]
					,_Fld8972 [ДатаОплаты]
					,_Fld8969RRef [СубконтоДт2]
					,_Fld8970RRef [СубконтоДт3]
					,_Fld8973 [ОтражатьВНалоговомУчете]
					,_Fld21849RRef [ФизЛицо]
					,_Fld21850RRef [ВалютаВзаиморасчетовРаботника]
					,_Fld8974 [Содержание_УСН]
					,_Fld8975 [Графа4_УСН]
					,_Fld8976 [Графа5_УСН]
					,_Fld8977 [Графа6_УСН]
					,_Fld8978 [Графа7_УСН]
					,_Fld8983RRef [Подразделение]
					,_Fld8984RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld8985RRef [СубконтоНУДт1]
					,_Fld8986RRef [СубконтоНУДт2]
					,_Fld8987RRef [СубконтоНУДт3]
					,_Fld8979 [ДоходыЕНВД_УСН]
					,_Fld8980 [РасходыЕНВД_УСН]
					,_Fld8981 [НДС_УСН]
					,_Fld8982 [РучнаяНастройка_УСН]
					,_Fld21851 [ДатаПогашенияАванса]
					,_Fld21852RRef [РасчетныйДокументРаботника]
					From _Document393(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(13);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(14);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(17);
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(22);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ДатаОплаты = Читалка.GetDateTime(27);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(33);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(36);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(37);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(43))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(44))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(45);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(46))[0]==1;
							Ссылка.ДатаПогашенияАванса = Читалка.GetDateTime(47);
							Ссылка.РасчетныйДокументРаботника = V82.ДокументыСсылка.АвансовыйОтчет.ВзятьИзКэша((byte[])Читалка.GetValue(48));
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
		
		public static ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств НайтиПоНомеру(string Номер)
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
					,_Fld8952_TYPE [РасчетныйДокумент_Тип],_Fld8952_RRRef [РасчетныйДокумент],_Fld8952_RTRef [РасчетныйДокумент_Вид]
					,_Fld8953_TYPE [ДокументОснование_Тип],_Fld8953_RRRef [ДокументОснование],_Fld8953_RTRef [ДокументОснование_Вид]
					,_Fld8954RRef [Организация]
					,_Fld8955RRef [СчетОрганизации]
					,_Fld8956RRef [Контрагент]
					,_Fld8957RRef [СчетКонтрагента]
					,_Fld18619 [НомерВходящегоДокумента]
					,_Fld18620 [ДатаВходящегоДокумента]
					,_Fld8958RRef [ДоговорКонтрагента]
					,_Fld8961 [ОтраженоВОперУчете]
					,_Fld8962 [Комментарий]
					,_Fld8960RRef [ВалютаДокумента]
					,_Fld8971 [Оплачено]
					,_Fld8965 [ОтражатьВБухгалтерскомУчете]
					,_Fld8963RRef [Ответственный]
					,_Fld8959 [СуммаДокумента]
					,_Fld8964RRef [ВидОперации]
					,_Fld8966RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8967RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8968RRef [СубконтоДт1]
					,_Fld8972 [ДатаОплаты]
					,_Fld8969RRef [СубконтоДт2]
					,_Fld8970RRef [СубконтоДт3]
					,_Fld8973 [ОтражатьВНалоговомУчете]
					,_Fld21849RRef [ФизЛицо]
					,_Fld21850RRef [ВалютаВзаиморасчетовРаботника]
					,_Fld8974 [Содержание_УСН]
					,_Fld8975 [Графа4_УСН]
					,_Fld8976 [Графа5_УСН]
					,_Fld8977 [Графа6_УСН]
					,_Fld8978 [Графа7_УСН]
					,_Fld8983RRef [Подразделение]
					,_Fld8984RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld8985RRef [СубконтоНУДт1]
					,_Fld8986RRef [СубконтоНУДт2]
					,_Fld8987RRef [СубконтоНУДт3]
					,_Fld8979 [ДоходыЕНВД_УСН]
					,_Fld8980 [РасходыЕНВД_УСН]
					,_Fld8981 [НДС_УСН]
					,_Fld8982 [РучнаяНастройка_УСН]
					,_Fld21851 [ДатаПогашенияАванса]
					,_Fld21852RRef [РасчетныйДокументРаботника]
					From _Document393(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(13);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(14);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(17);
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(22);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ДатаОплаты = Читалка.GetDateTime(27);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(33);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(36);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(37);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(43))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(44))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(45);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(46))[0]==1;
							Ссылка.ДатаПогашенияАванса = Читалка.GetDateTime(47);
							Ссылка.РасчетныйДокументРаботника = V82.ДокументыСсылка.АвансовыйОтчет.ВзятьИзКэша((byte[])Читалка.GetValue(48));
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
		
		public static ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств Выбрать()
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
					,_Fld8952_TYPE [РасчетныйДокумент_Тип],_Fld8952_RRRef [РасчетныйДокумент],_Fld8952_RTRef [РасчетныйДокумент_Вид]
					,_Fld8953_TYPE [ДокументОснование_Тип],_Fld8953_RRRef [ДокументОснование],_Fld8953_RTRef [ДокументОснование_Вид]
					,_Fld8954RRef [Организация]
					,_Fld8955RRef [СчетОрганизации]
					,_Fld8956RRef [Контрагент]
					,_Fld8957RRef [СчетКонтрагента]
					,_Fld18619 [НомерВходящегоДокумента]
					,_Fld18620 [ДатаВходящегоДокумента]
					,_Fld8958RRef [ДоговорКонтрагента]
					,_Fld8961 [ОтраженоВОперУчете]
					,_Fld8962 [Комментарий]
					,_Fld8960RRef [ВалютаДокумента]
					,_Fld8971 [Оплачено]
					,_Fld8965 [ОтражатьВБухгалтерскомУчете]
					,_Fld8963RRef [Ответственный]
					,_Fld8959 [СуммаДокумента]
					,_Fld8964RRef [ВидОперации]
					,_Fld8966RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8967RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8968RRef [СубконтоДт1]
					,_Fld8972 [ДатаОплаты]
					,_Fld8969RRef [СубконтоДт2]
					,_Fld8970RRef [СубконтоДт3]
					,_Fld8973 [ОтражатьВНалоговомУчете]
					,_Fld21849RRef [ФизЛицо]
					,_Fld21850RRef [ВалютаВзаиморасчетовРаботника]
					,_Fld8974 [Содержание_УСН]
					,_Fld8975 [Графа4_УСН]
					,_Fld8976 [Графа5_УСН]
					,_Fld8977 [Графа6_УСН]
					,_Fld8978 [Графа7_УСН]
					,_Fld8983RRef [Подразделение]
					,_Fld8984RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld8985RRef [СубконтоНУДт1]
					,_Fld8986RRef [СубконтоНУДт2]
					,_Fld8987RRef [СубконтоНУДт3]
					,_Fld8979 [ДоходыЕНВД_УСН]
					,_Fld8980 [РасходыЕНВД_УСН]
					,_Fld8981 [НДС_УСН]
					,_Fld8982 [РучнаяНастройка_УСН]
					,_Fld21851 [ДатаПогашенияАванса]
					,_Fld21852RRef [РасчетныйДокументРаботника]
					From _Document393(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(13);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(14);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(17);
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(22);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ДатаОплаты = Читалка.GetDateTime(27);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(33);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(36);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(37);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(43))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(44))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(45);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(46))[0]==1;
							Ссылка.ДатаПогашенияАванса = Читалка.GetDateTime(47);
							Ссылка.РасчетныйДокументРаботника = V82.ДокументыСсылка.АвансовыйОтчет.ВзятьИзКэша((byte[])Читалка.GetValue(48));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld8952_TYPE [РасчетныйДокумент_Тип],_Fld8952_RRRef [РасчетныйДокумент],_Fld8952_RTRef [РасчетныйДокумент_Вид]
					,_Fld8953_TYPE [ДокументОснование_Тип],_Fld8953_RRRef [ДокументОснование],_Fld8953_RTRef [ДокументОснование_Вид]
					,_Fld8954RRef [Организация]
					,_Fld8955RRef [СчетОрганизации]
					,_Fld8956RRef [Контрагент]
					,_Fld8957RRef [СчетКонтрагента]
					,_Fld18619 [НомерВходящегоДокумента]
					,_Fld18620 [ДатаВходящегоДокумента]
					,_Fld8958RRef [ДоговорКонтрагента]
					,_Fld8961 [ОтраженоВОперУчете]
					,_Fld8962 [Комментарий]
					,_Fld8960RRef [ВалютаДокумента]
					,_Fld8971 [Оплачено]
					,_Fld8965 [ОтражатьВБухгалтерскомУчете]
					,_Fld8963RRef [Ответственный]
					,_Fld8959 [СуммаДокумента]
					,_Fld8964RRef [ВидОперации]
					,_Fld8966RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8967RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8968RRef [СубконтоДт1]
					,_Fld8972 [ДатаОплаты]
					,_Fld8969RRef [СубконтоДт2]
					,_Fld8970RRef [СубконтоДт3]
					,_Fld8973 [ОтражатьВНалоговомУчете]
					,_Fld21849RRef [ФизЛицо]
					,_Fld21850RRef [ВалютаВзаиморасчетовРаботника]
					,_Fld8974 [Содержание_УСН]
					,_Fld8975 [Графа4_УСН]
					,_Fld8976 [Графа5_УСН]
					,_Fld8977 [Графа6_УСН]
					,_Fld8978 [Графа7_УСН]
					,_Fld8983RRef [Подразделение]
					,_Fld8984RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld8985RRef [СубконтоНУДт1]
					,_Fld8986RRef [СубконтоНУДт2]
					,_Fld8987RRef [СубконтоНУДт3]
					,_Fld8979 [ДоходыЕНВД_УСН]
					,_Fld8980 [РасходыЕНВД_УСН]
					,_Fld8981 [НДС_УСН]
					,_Fld8982 [РучнаяНастройка_УСН]
					,_Fld21851 [ДатаПогашенияАванса]
					,_Fld21852RRef [РасчетныйДокументРаботника]
					From _Document393(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(13);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(14);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(17);
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(22);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ДатаОплаты = Читалка.GetDateTime(27);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(33);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(36);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(37);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(43))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(44))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(45);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(46))[0]==1;
							Ссылка.ДатаПогашенияАванса = Читалка.GetDateTime(47);
							Ссылка.РасчетныйДокументРаботника = V82.ДокументыСсылка.АвансовыйОтчет.ВзятьИзКэша((byte[])Читалка.GetValue(48));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld8952_TYPE [РасчетныйДокумент_Тип],_Fld8952_RRRef [РасчетныйДокумент],_Fld8952_RTRef [РасчетныйДокумент_Вид]
					,_Fld8953_TYPE [ДокументОснование_Тип],_Fld8953_RRRef [ДокументОснование],_Fld8953_RTRef [ДокументОснование_Вид]
					,_Fld8954RRef [Организация]
					,_Fld8955RRef [СчетОрганизации]
					,_Fld8956RRef [Контрагент]
					,_Fld8957RRef [СчетКонтрагента]
					,_Fld18619 [НомерВходящегоДокумента]
					,_Fld18620 [ДатаВходящегоДокумента]
					,_Fld8958RRef [ДоговорКонтрагента]
					,_Fld8961 [ОтраженоВОперУчете]
					,_Fld8962 [Комментарий]
					,_Fld8960RRef [ВалютаДокумента]
					,_Fld8971 [Оплачено]
					,_Fld8965 [ОтражатьВБухгалтерскомУчете]
					,_Fld8963RRef [Ответственный]
					,_Fld8959 [СуммаДокумента]
					,_Fld8964RRef [ВидОперации]
					,_Fld8966RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8967RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8968RRef [СубконтоДт1]
					,_Fld8972 [ДатаОплаты]
					,_Fld8969RRef [СубконтоДт2]
					,_Fld8970RRef [СубконтоДт3]
					,_Fld8973 [ОтражатьВНалоговомУчете]
					,_Fld21849RRef [ФизЛицо]
					,_Fld21850RRef [ВалютаВзаиморасчетовРаботника]
					,_Fld8974 [Содержание_УСН]
					,_Fld8975 [Графа4_УСН]
					,_Fld8976 [Графа5_УСН]
					,_Fld8977 [Графа6_УСН]
					,_Fld8978 [Графа7_УСН]
					,_Fld8983RRef [Подразделение]
					,_Fld8984RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld8985RRef [СубконтоНУДт1]
					,_Fld8986RRef [СубконтоНУДт2]
					,_Fld8987RRef [СубконтоНУДт3]
					,_Fld8979 [ДоходыЕНВД_УСН]
					,_Fld8980 [РасходыЕНВД_УСН]
					,_Fld8981 [НДС_УСН]
					,_Fld8982 [РучнаяНастройка_УСН]
					,_Fld21851 [ДатаПогашенияАванса]
					,_Fld21852RRef [РасчетныйДокументРаботника]
					From _Document393(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(13);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(14);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(17);
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(22);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ДатаОплаты = Читалка.GetDateTime(27);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(33);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(36);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(37);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(43))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(44))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(45);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(46))[0]==1;
							Ссылка.ДатаПогашенияАванса = Читалка.GetDateTime(47);
							Ссылка.РасчетныйДокументРаботника = V82.ДокументыСсылка.АвансовыйОтчет.ВзятьИзКэша((byte[])Читалка.GetValue(48));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld8952_TYPE [РасчетныйДокумент_Тип],_Fld8952_RRRef [РасчетныйДокумент],_Fld8952_RTRef [РасчетныйДокумент_Вид]
					,_Fld8953_TYPE [ДокументОснование_Тип],_Fld8953_RRRef [ДокументОснование],_Fld8953_RTRef [ДокументОснование_Вид]
					,_Fld8954RRef [Организация]
					,_Fld8955RRef [СчетОрганизации]
					,_Fld8956RRef [Контрагент]
					,_Fld8957RRef [СчетКонтрагента]
					,_Fld18619 [НомерВходящегоДокумента]
					,_Fld18620 [ДатаВходящегоДокумента]
					,_Fld8958RRef [ДоговорКонтрагента]
					,_Fld8961 [ОтраженоВОперУчете]
					,_Fld8962 [Комментарий]
					,_Fld8960RRef [ВалютаДокумента]
					,_Fld8971 [Оплачено]
					,_Fld8965 [ОтражатьВБухгалтерскомУчете]
					,_Fld8963RRef [Ответственный]
					,_Fld8959 [СуммаДокумента]
					,_Fld8964RRef [ВидОперации]
					,_Fld8966RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8967RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8968RRef [СубконтоДт1]
					,_Fld8972 [ДатаОплаты]
					,_Fld8969RRef [СубконтоДт2]
					,_Fld8970RRef [СубконтоДт3]
					,_Fld8973 [ОтражатьВНалоговомУчете]
					,_Fld21849RRef [ФизЛицо]
					,_Fld21850RRef [ВалютаВзаиморасчетовРаботника]
					,_Fld8974 [Содержание_УСН]
					,_Fld8975 [Графа4_УСН]
					,_Fld8976 [Графа5_УСН]
					,_Fld8977 [Графа6_УСН]
					,_Fld8978 [Графа7_УСН]
					,_Fld8983RRef [Подразделение]
					,_Fld8984RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld8985RRef [СубконтоНУДт1]
					,_Fld8986RRef [СубконтоНУДт2]
					,_Fld8987RRef [СубконтоНУДт3]
					,_Fld8979 [ДоходыЕНВД_УСН]
					,_Fld8980 [РасходыЕНВД_УСН]
					,_Fld8981 [НДС_УСН]
					,_Fld8982 [РучнаяНастройка_УСН]
					,_Fld21851 [ДатаПогашенияАванса]
					,_Fld21852RRef [РасчетныйДокументРаботника]
					From _Document393(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(13);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(14);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(17);
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(22);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ДатаОплаты = Читалка.GetDateTime(27);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(33);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(36);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(37);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(43))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(44))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(45);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(46))[0]==1;
							Ссылка.ДатаПогашенияАванса = Читалка.GetDateTime(47);
							Ссылка.РасчетныйДокументРаботника = V82.ДокументыСсылка.АвансовыйОтчет.ВзятьИзКэша((byte[])Читалка.GetValue(48));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld8952_TYPE [РасчетныйДокумент_Тип],_Fld8952_RRRef [РасчетныйДокумент],_Fld8952_RTRef [РасчетныйДокумент_Вид]
					,_Fld8953_TYPE [ДокументОснование_Тип],_Fld8953_RRRef [ДокументОснование],_Fld8953_RTRef [ДокументОснование_Вид]
					,_Fld8954RRef [Организация]
					,_Fld8955RRef [СчетОрганизации]
					,_Fld8956RRef [Контрагент]
					,_Fld8957RRef [СчетКонтрагента]
					,_Fld18619 [НомерВходящегоДокумента]
					,_Fld18620 [ДатаВходящегоДокумента]
					,_Fld8958RRef [ДоговорКонтрагента]
					,_Fld8961 [ОтраженоВОперУчете]
					,_Fld8962 [Комментарий]
					,_Fld8960RRef [ВалютаДокумента]
					,_Fld8971 [Оплачено]
					,_Fld8965 [ОтражатьВБухгалтерскомУчете]
					,_Fld8963RRef [Ответственный]
					,_Fld8959 [СуммаДокумента]
					,_Fld8964RRef [ВидОперации]
					,_Fld8966RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8967RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8968RRef [СубконтоДт1]
					,_Fld8972 [ДатаОплаты]
					,_Fld8969RRef [СубконтоДт2]
					,_Fld8970RRef [СубконтоДт3]
					,_Fld8973 [ОтражатьВНалоговомУчете]
					,_Fld21849RRef [ФизЛицо]
					,_Fld21850RRef [ВалютаВзаиморасчетовРаботника]
					,_Fld8974 [Содержание_УСН]
					,_Fld8975 [Графа4_УСН]
					,_Fld8976 [Графа5_УСН]
					,_Fld8977 [Графа6_УСН]
					,_Fld8978 [Графа7_УСН]
					,_Fld8983RRef [Подразделение]
					,_Fld8984RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld8985RRef [СубконтоНУДт1]
					,_Fld8986RRef [СубконтоНУДт2]
					,_Fld8987RRef [СубконтоНУДт3]
					,_Fld8979 [ДоходыЕНВД_УСН]
					,_Fld8980 [РасходыЕНВД_УСН]
					,_Fld8981 [НДС_УСН]
					,_Fld8982 [РучнаяНастройка_УСН]
					,_Fld21851 [ДатаПогашенияАванса]
					,_Fld21852RRef [РасчетныйДокументРаботника]
					From _Document393(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПлатежныйОрдерСписаниеДенежныхСредств();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежныйОрдерСписаниеДенежныхСредств();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(13);
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(14);
							Ссылка.ОтраженоВОперУчете = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(17);
							Ссылка.Оплачено = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(22);
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(23));
							Ссылка.ДатаОплаты = Читалка.GetDateTime(27);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(30))[0]==1;
							Ссылка.Содержание_УСН = Читалка.GetString(33);
							Ссылка.Графа4_УСН = Читалка.GetDecimal(34);
							Ссылка.Графа5_УСН = Читалка.GetDecimal(35);
							Ссылка.Графа6_УСН = Читалка.GetDecimal(36);
							Ссылка.Графа7_УСН = Читалка.GetDecimal(37);
							Ссылка.ДоходыЕНВД_УСН = ((byte[])Читалка.GetValue(43))[0]==1;
							Ссылка.РасходыЕНВД_УСН = ((byte[])Читалка.GetValue(44))[0]==1;
							Ссылка.НДС_УСН = Читалка.GetDecimal(45);
							Ссылка.РучнаяНастройка_УСН = ((byte[])Читалка.GetValue(46))[0]==1;
							Ссылка.ДатаПогашенияАванса = Читалка.GetDateTime(47);
							Ссылка.РасчетныйДокументРаботника = V82.ДокументыСсылка.АвансовыйОтчет.ВзятьИзКэша((byte[])Читалка.GetValue(48));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ПлатежныйОрдерСписаниеДенежныхСредств СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ПлатежныйОрдерСписаниеДенежныхСредств();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.НомерВходящегоДокумента = "";
			Объект.Комментарий = "";
			Объект.Содержание_УСН = "";
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийСписаниеБезналичныхДенежныхСредств.ПустаяСсылка;
			Объект.РасчетныйДокументРаботника = new V82.ДокументыСсылка.АвансовыйОтчет();
			return Объект;
		}
	}
}