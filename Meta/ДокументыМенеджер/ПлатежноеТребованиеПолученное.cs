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
	public partial class ПлатежноеТребованиеПолученное:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ПлатежноеТребованиеПолученное НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld8808_TYPE [ДокументОснование_Тип],_Fld8808_RRRef [ДокументОснование],_Fld8808_RTRef [ДокументОснование_Вид]
					,_Fld8809 [НомерВходящегоДокумента]
					,_Fld8810 [ДатаВходящегоДокумента]
					,_Fld8811RRef [Организация]
					,_Fld8812RRef [СчетОрганизации]
					,_Fld8813RRef [Контрагент]
					,_Fld8814RRef [СчетКонтрагента]
					,_Fld8815 [ВидПлатежа]
					,_Fld8816 [ОчередностьПлатежа]
					,_Fld8817 [НазначениеПлатежа]
					,_Fld8818 [СуммаДокумента]
					,_Fld8819RRef [ВалютаДокумента]
					,_Fld8820RRef [ДоговорКонтрагента]
					,_Fld8821 [ОтраженоВОперУчете]
					,_Fld8822 [Оплачено]
					,_Fld8823 [ДатаОплаты]
					,_Fld8824 [Комментарий]
					,_Fld8825RRef [Ответственный]
					,_Fld8826RRef [ВидОперации]
					,_Fld8827 [ОтражатьВБухгалтерскомУчете]
					,_Fld8828RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8829RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8830RRef [СубконтоДт1]
					,_Fld8831RRef [СубконтоДт2]
					,_Fld8832RRef [СубконтоДт3]
					,_Fld8833 [ЧастичнаяОплата]
					,_Fld8834 [ОтражатьВНалоговомУчете]
					,_Fld8835 [Содержание_УСН]
					,_Fld8836 [Графа4_УСН]
					,_Fld8837 [Графа5_УСН]
					,_Fld8838 [Графа6_УСН]
					,_Fld8839 [Графа7_УСН]
					,_Fld8840 [ДоходыЕНВД_УСН]
					,_Fld8841 [РасходыЕНВД_УСН]
					,_Fld8842 [НДС_УСН]
					,_Fld8843 [РучнаяНастройка_УСН]
					,_Fld8844RRef [Подразделение]
					,_Fld19510RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld19511RRef [СубконтоНУДт1]
					,_Fld19512RRef [СубконтоНУДт2]
					,_Fld19513RRef [СубконтоНУДт3]
					From _Document391(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежноеТребованиеПолученное();
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
		
		public static ДокументыСсылка.ПлатежноеТребованиеПолученное НайтиПоНомеру(string Номер)
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
					,_Fld8808_TYPE [ДокументОснование_Тип],_Fld8808_RRRef [ДокументОснование],_Fld8808_RTRef [ДокументОснование_Вид]
					,_Fld8809 [НомерВходящегоДокумента]
					,_Fld8810 [ДатаВходящегоДокумента]
					,_Fld8811RRef [Организация]
					,_Fld8812RRef [СчетОрганизации]
					,_Fld8813RRef [Контрагент]
					,_Fld8814RRef [СчетКонтрагента]
					,_Fld8815 [ВидПлатежа]
					,_Fld8816 [ОчередностьПлатежа]
					,_Fld8817 [НазначениеПлатежа]
					,_Fld8818 [СуммаДокумента]
					,_Fld8819RRef [ВалютаДокумента]
					,_Fld8820RRef [ДоговорКонтрагента]
					,_Fld8821 [ОтраженоВОперУчете]
					,_Fld8822 [Оплачено]
					,_Fld8823 [ДатаОплаты]
					,_Fld8824 [Комментарий]
					,_Fld8825RRef [Ответственный]
					,_Fld8826RRef [ВидОперации]
					,_Fld8827 [ОтражатьВБухгалтерскомУчете]
					,_Fld8828RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8829RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8830RRef [СубконтоДт1]
					,_Fld8831RRef [СубконтоДт2]
					,_Fld8832RRef [СубконтоДт3]
					,_Fld8833 [ЧастичнаяОплата]
					,_Fld8834 [ОтражатьВНалоговомУчете]
					,_Fld8835 [Содержание_УСН]
					,_Fld8836 [Графа4_УСН]
					,_Fld8837 [Графа5_УСН]
					,_Fld8838 [Графа6_УСН]
					,_Fld8839 [Графа7_УСН]
					,_Fld8840 [ДоходыЕНВД_УСН]
					,_Fld8841 [РасходыЕНВД_УСН]
					,_Fld8842 [НДС_УСН]
					,_Fld8843 [РучнаяНастройка_УСН]
					,_Fld8844RRef [Подразделение]
					,_Fld19510RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld19511RRef [СубконтоНУДт1]
					,_Fld19512RRef [СубконтоНУДт2]
					,_Fld19513RRef [СубконтоНУДт3]
					From _Document391(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежноеТребованиеПолученное();
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
		
		public static ДокументыВыборка.ПлатежноеТребованиеПолученное Выбрать()
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
					,_Fld8808_TYPE [ДокументОснование_Тип],_Fld8808_RRRef [ДокументОснование],_Fld8808_RTRef [ДокументОснование_Вид]
					,_Fld8809 [НомерВходящегоДокумента]
					,_Fld8810 [ДатаВходящегоДокумента]
					,_Fld8811RRef [Организация]
					,_Fld8812RRef [СчетОрганизации]
					,_Fld8813RRef [Контрагент]
					,_Fld8814RRef [СчетКонтрагента]
					,_Fld8815 [ВидПлатежа]
					,_Fld8816 [ОчередностьПлатежа]
					,_Fld8817 [НазначениеПлатежа]
					,_Fld8818 [СуммаДокумента]
					,_Fld8819RRef [ВалютаДокумента]
					,_Fld8820RRef [ДоговорКонтрагента]
					,_Fld8821 [ОтраженоВОперУчете]
					,_Fld8822 [Оплачено]
					,_Fld8823 [ДатаОплаты]
					,_Fld8824 [Комментарий]
					,_Fld8825RRef [Ответственный]
					,_Fld8826RRef [ВидОперации]
					,_Fld8827 [ОтражатьВБухгалтерскомУчете]
					,_Fld8828RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8829RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8830RRef [СубконтоДт1]
					,_Fld8831RRef [СубконтоДт2]
					,_Fld8832RRef [СубконтоДт3]
					,_Fld8833 [ЧастичнаяОплата]
					,_Fld8834 [ОтражатьВНалоговомУчете]
					,_Fld8835 [Содержание_УСН]
					,_Fld8836 [Графа4_УСН]
					,_Fld8837 [Графа5_УСН]
					,_Fld8838 [Графа6_УСН]
					,_Fld8839 [Графа7_УСН]
					,_Fld8840 [ДоходыЕНВД_УСН]
					,_Fld8841 [РасходыЕНВД_УСН]
					,_Fld8842 [НДС_УСН]
					,_Fld8843 [РучнаяНастройка_УСН]
					,_Fld8844RRef [Подразделение]
					,_Fld19510RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld19511RRef [СубконтоНУДт1]
					,_Fld19512RRef [СубконтоНУДт2]
					,_Fld19513RRef [СубконтоНУДт3]
					From _Document391(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПлатежноеТребованиеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежноеТребованиеПолученное();
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
		
		public static ДокументыВыборка.ПлатежноеТребованиеПолученное ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld8808_TYPE [ДокументОснование_Тип],_Fld8808_RRRef [ДокументОснование],_Fld8808_RTRef [ДокументОснование_Вид]
					,_Fld8809 [НомерВходящегоДокумента]
					,_Fld8810 [ДатаВходящегоДокумента]
					,_Fld8811RRef [Организация]
					,_Fld8812RRef [СчетОрганизации]
					,_Fld8813RRef [Контрагент]
					,_Fld8814RRef [СчетКонтрагента]
					,_Fld8815 [ВидПлатежа]
					,_Fld8816 [ОчередностьПлатежа]
					,_Fld8817 [НазначениеПлатежа]
					,_Fld8818 [СуммаДокумента]
					,_Fld8819RRef [ВалютаДокумента]
					,_Fld8820RRef [ДоговорКонтрагента]
					,_Fld8821 [ОтраженоВОперУчете]
					,_Fld8822 [Оплачено]
					,_Fld8823 [ДатаОплаты]
					,_Fld8824 [Комментарий]
					,_Fld8825RRef [Ответственный]
					,_Fld8826RRef [ВидОперации]
					,_Fld8827 [ОтражатьВБухгалтерскомУчете]
					,_Fld8828RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8829RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8830RRef [СубконтоДт1]
					,_Fld8831RRef [СубконтоДт2]
					,_Fld8832RRef [СубконтоДт3]
					,_Fld8833 [ЧастичнаяОплата]
					,_Fld8834 [ОтражатьВНалоговомУчете]
					,_Fld8835 [Содержание_УСН]
					,_Fld8836 [Графа4_УСН]
					,_Fld8837 [Графа5_УСН]
					,_Fld8838 [Графа6_УСН]
					,_Fld8839 [Графа7_УСН]
					,_Fld8840 [ДоходыЕНВД_УСН]
					,_Fld8841 [РасходыЕНВД_УСН]
					,_Fld8842 [НДС_УСН]
					,_Fld8843 [РучнаяНастройка_УСН]
					,_Fld8844RRef [Подразделение]
					,_Fld19510RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld19511RRef [СубконтоНУДт1]
					,_Fld19512RRef [СубконтоНУДт2]
					,_Fld19513RRef [СубконтоНУДт3]
					From _Document391(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПлатежноеТребованиеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежноеТребованиеПолученное();
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
		
		public static ДокументыВыборка.ПлатежноеТребованиеПолученное ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld8808_TYPE [ДокументОснование_Тип],_Fld8808_RRRef [ДокументОснование],_Fld8808_RTRef [ДокументОснование_Вид]
					,_Fld8809 [НомерВходящегоДокумента]
					,_Fld8810 [ДатаВходящегоДокумента]
					,_Fld8811RRef [Организация]
					,_Fld8812RRef [СчетОрганизации]
					,_Fld8813RRef [Контрагент]
					,_Fld8814RRef [СчетКонтрагента]
					,_Fld8815 [ВидПлатежа]
					,_Fld8816 [ОчередностьПлатежа]
					,_Fld8817 [НазначениеПлатежа]
					,_Fld8818 [СуммаДокумента]
					,_Fld8819RRef [ВалютаДокумента]
					,_Fld8820RRef [ДоговорКонтрагента]
					,_Fld8821 [ОтраженоВОперУчете]
					,_Fld8822 [Оплачено]
					,_Fld8823 [ДатаОплаты]
					,_Fld8824 [Комментарий]
					,_Fld8825RRef [Ответственный]
					,_Fld8826RRef [ВидОперации]
					,_Fld8827 [ОтражатьВБухгалтерскомУчете]
					,_Fld8828RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8829RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8830RRef [СубконтоДт1]
					,_Fld8831RRef [СубконтоДт2]
					,_Fld8832RRef [СубконтоДт3]
					,_Fld8833 [ЧастичнаяОплата]
					,_Fld8834 [ОтражатьВНалоговомУчете]
					,_Fld8835 [Содержание_УСН]
					,_Fld8836 [Графа4_УСН]
					,_Fld8837 [Графа5_УСН]
					,_Fld8838 [Графа6_УСН]
					,_Fld8839 [Графа7_УСН]
					,_Fld8840 [ДоходыЕНВД_УСН]
					,_Fld8841 [РасходыЕНВД_УСН]
					,_Fld8842 [НДС_УСН]
					,_Fld8843 [РучнаяНастройка_УСН]
					,_Fld8844RRef [Подразделение]
					,_Fld19510RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld19511RRef [СубконтоНУДт1]
					,_Fld19512RRef [СубконтоНУДт2]
					,_Fld19513RRef [СубконтоНУДт3]
					From _Document391(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПлатежноеТребованиеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежноеТребованиеПолученное();
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
		
		public static ДокументыВыборка.ПлатежноеТребованиеПолученное СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld8808_TYPE [ДокументОснование_Тип],_Fld8808_RRRef [ДокументОснование],_Fld8808_RTRef [ДокументОснование_Вид]
					,_Fld8809 [НомерВходящегоДокумента]
					,_Fld8810 [ДатаВходящегоДокумента]
					,_Fld8811RRef [Организация]
					,_Fld8812RRef [СчетОрганизации]
					,_Fld8813RRef [Контрагент]
					,_Fld8814RRef [СчетКонтрагента]
					,_Fld8815 [ВидПлатежа]
					,_Fld8816 [ОчередностьПлатежа]
					,_Fld8817 [НазначениеПлатежа]
					,_Fld8818 [СуммаДокумента]
					,_Fld8819RRef [ВалютаДокумента]
					,_Fld8820RRef [ДоговорКонтрагента]
					,_Fld8821 [ОтраженоВОперУчете]
					,_Fld8822 [Оплачено]
					,_Fld8823 [ДатаОплаты]
					,_Fld8824 [Комментарий]
					,_Fld8825RRef [Ответственный]
					,_Fld8826RRef [ВидОперации]
					,_Fld8827 [ОтражатьВБухгалтерскомУчете]
					,_Fld8828RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8829RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8830RRef [СубконтоДт1]
					,_Fld8831RRef [СубконтоДт2]
					,_Fld8832RRef [СубконтоДт3]
					,_Fld8833 [ЧастичнаяОплата]
					,_Fld8834 [ОтражатьВНалоговомУчете]
					,_Fld8835 [Содержание_УСН]
					,_Fld8836 [Графа4_УСН]
					,_Fld8837 [Графа5_УСН]
					,_Fld8838 [Графа6_УСН]
					,_Fld8839 [Графа7_УСН]
					,_Fld8840 [ДоходыЕНВД_УСН]
					,_Fld8841 [РасходыЕНВД_УСН]
					,_Fld8842 [НДС_УСН]
					,_Fld8843 [РучнаяНастройка_УСН]
					,_Fld8844RRef [Подразделение]
					,_Fld19510RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld19511RRef [СубконтоНУДт1]
					,_Fld19512RRef [СубконтоНУДт2]
					,_Fld19513RRef [СубконтоНУДт3]
					From _Document391(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПлатежноеТребованиеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежноеТребованиеПолученное();
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
		
		public static ДокументыВыборка.ПлатежноеТребованиеПолученное СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld8808_TYPE [ДокументОснование_Тип],_Fld8808_RRRef [ДокументОснование],_Fld8808_RTRef [ДокументОснование_Вид]
					,_Fld8809 [НомерВходящегоДокумента]
					,_Fld8810 [ДатаВходящегоДокумента]
					,_Fld8811RRef [Организация]
					,_Fld8812RRef [СчетОрганизации]
					,_Fld8813RRef [Контрагент]
					,_Fld8814RRef [СчетКонтрагента]
					,_Fld8815 [ВидПлатежа]
					,_Fld8816 [ОчередностьПлатежа]
					,_Fld8817 [НазначениеПлатежа]
					,_Fld8818 [СуммаДокумента]
					,_Fld8819RRef [ВалютаДокумента]
					,_Fld8820RRef [ДоговорКонтрагента]
					,_Fld8821 [ОтраженоВОперУчете]
					,_Fld8822 [Оплачено]
					,_Fld8823 [ДатаОплаты]
					,_Fld8824 [Комментарий]
					,_Fld8825RRef [Ответственный]
					,_Fld8826RRef [ВидОперации]
					,_Fld8827 [ОтражатьВБухгалтерскомУчете]
					,_Fld8828RRef [СтатьяДвиженияДенежныхСредств]
					,_Fld8829RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld8830RRef [СубконтоДт1]
					,_Fld8831RRef [СубконтоДт2]
					,_Fld8832RRef [СубконтоДт3]
					,_Fld8833 [ЧастичнаяОплата]
					,_Fld8834 [ОтражатьВНалоговомУчете]
					,_Fld8835 [Содержание_УСН]
					,_Fld8836 [Графа4_УСН]
					,_Fld8837 [Графа5_УСН]
					,_Fld8838 [Графа6_УСН]
					,_Fld8839 [Графа7_УСН]
					,_Fld8840 [ДоходыЕНВД_УСН]
					,_Fld8841 [РасходыЕНВД_УСН]
					,_Fld8842 [НДС_УСН]
					,_Fld8843 [РучнаяНастройка_УСН]
					,_Fld8844RRef [Подразделение]
					,_Fld19510RRef [СчетУчетаРасчетовСКонтрагентомНУ]
					,_Fld19511RRef [СубконтоНУДт1]
					,_Fld19512RRef [СубконтоНУДт2]
					,_Fld19513RRef [СубконтоНУДт3]
					From _Document391(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПлатежноеТребованиеПолученное();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПлатежноеТребованиеПолученное();
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
		
		public static V82.ДокументыОбъект.ПлатежноеТребованиеПолученное СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ПлатежноеТребованиеПолученное();
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