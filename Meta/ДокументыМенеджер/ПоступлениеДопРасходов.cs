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
	///(Общ) Поступление расходов, относимых на стоимость товаров
	///</summary>
	public partial class ПоступлениеДопРасходов:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ПоступлениеДопРасходов НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld9244RRef [ВалютаДокумента]
					,_Fld9245RRef [ВидОперации]
					,_Fld9246RRef [ДоговорКонтрагента]
					,_Fld9247 [Комментарий]
					,_Fld9248RRef [Контрагент]
					,_Fld9249 [КратностьВзаиморасчетов]
					,_Fld9250 [КурсВзаиморасчетов]
					,_Fld9251RRef [Организация]
					,_Fld9252 [ОтражатьВУправленческомУчете]
					,_Fld9253 [ОтражатьВБухгалтерскомУчете]
					,_Fld9254 [ОтражатьВНалоговомУчете]
					,_Fld9255RRef [Подразделение]
					,_Fld9257 [Содержание]
					,_Fld9258RRef [СпособРаспределения]
					,_Fld9259RRef [СтавкаНДС]
					,_Fld9260 [Сумма]
					,_Fld9261 [СуммаВключаетНДС]
					,_Fld9262 [СуммаДокумента]
					,_Fld9263 [СуммаНДС]
					,_Fld9264 [УчитыватьНДС]
					,_Fld9265RRef [Ответственный]
					,_Fld9266RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld9267RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld9268 [НДСВключенВСтоимость]
					,_Fld9256_TYPE [Сделка_Тип],_Fld9256_RRRef [Сделка],_Fld9256_RTRef [Сделка_Вид]
					,_Fld9270 [ДатаВходящегоДокумента]
					,_Fld9269 [НомерВходящегоДокумента]
					From _Document400(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПоступлениеДопРасходов();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(11))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Ссылка.Содержание = Читалка.GetString(15);
							Ссылка.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(16));
							Ссылка.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(17));
							Ссылка.Сумма = Читалка.GetDecimal(18);
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(20);
							Ссылка.СуммаНДС = Читалка.GetDecimal(21);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(22))[0]==1;
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(26))[0]==1;
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(30);
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(31);
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
		
		public static ДокументыСсылка.ПоступлениеДопРасходов НайтиПоНомеру(string Номер)
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
					,_Fld9244RRef [ВалютаДокумента]
					,_Fld9245RRef [ВидОперации]
					,_Fld9246RRef [ДоговорКонтрагента]
					,_Fld9247 [Комментарий]
					,_Fld9248RRef [Контрагент]
					,_Fld9249 [КратностьВзаиморасчетов]
					,_Fld9250 [КурсВзаиморасчетов]
					,_Fld9251RRef [Организация]
					,_Fld9252 [ОтражатьВУправленческомУчете]
					,_Fld9253 [ОтражатьВБухгалтерскомУчете]
					,_Fld9254 [ОтражатьВНалоговомУчете]
					,_Fld9255RRef [Подразделение]
					,_Fld9257 [Содержание]
					,_Fld9258RRef [СпособРаспределения]
					,_Fld9259RRef [СтавкаНДС]
					,_Fld9260 [Сумма]
					,_Fld9261 [СуммаВключаетНДС]
					,_Fld9262 [СуммаДокумента]
					,_Fld9263 [СуммаНДС]
					,_Fld9264 [УчитыватьНДС]
					,_Fld9265RRef [Ответственный]
					,_Fld9266RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld9267RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld9268 [НДСВключенВСтоимость]
					,_Fld9256_TYPE [Сделка_Тип],_Fld9256_RRRef [Сделка],_Fld9256_RTRef [Сделка_Вид]
					,_Fld9270 [ДатаВходящегоДокумента]
					,_Fld9269 [НомерВходящегоДокумента]
					From _Document400(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПоступлениеДопРасходов();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(11))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Ссылка.Содержание = Читалка.GetString(15);
							Ссылка.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(16));
							Ссылка.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(17));
							Ссылка.Сумма = Читалка.GetDecimal(18);
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(20);
							Ссылка.СуммаНДС = Читалка.GetDecimal(21);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(22))[0]==1;
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(26))[0]==1;
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(30);
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(31);
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
		
		public static ДокументыВыборка.ПоступлениеДопРасходов Выбрать()
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
					,_Fld9244RRef [ВалютаДокумента]
					,_Fld9245RRef [ВидОперации]
					,_Fld9246RRef [ДоговорКонтрагента]
					,_Fld9247 [Комментарий]
					,_Fld9248RRef [Контрагент]
					,_Fld9249 [КратностьВзаиморасчетов]
					,_Fld9250 [КурсВзаиморасчетов]
					,_Fld9251RRef [Организация]
					,_Fld9252 [ОтражатьВУправленческомУчете]
					,_Fld9253 [ОтражатьВБухгалтерскомУчете]
					,_Fld9254 [ОтражатьВНалоговомУчете]
					,_Fld9255RRef [Подразделение]
					,_Fld9257 [Содержание]
					,_Fld9258RRef [СпособРаспределения]
					,_Fld9259RRef [СтавкаНДС]
					,_Fld9260 [Сумма]
					,_Fld9261 [СуммаВключаетНДС]
					,_Fld9262 [СуммаДокумента]
					,_Fld9263 [СуммаНДС]
					,_Fld9264 [УчитыватьНДС]
					,_Fld9265RRef [Ответственный]
					,_Fld9266RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld9267RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld9268 [НДСВключенВСтоимость]
					,_Fld9256_TYPE [Сделка_Тип],_Fld9256_RRRef [Сделка],_Fld9256_RTRef [Сделка_Вид]
					,_Fld9270 [ДатаВходящегоДокумента]
					,_Fld9269 [НомерВходящегоДокумента]
					From _Document400(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПоступлениеДопРасходов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПоступлениеДопРасходов();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(11))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Ссылка.Содержание = Читалка.GetString(15);
							Ссылка.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(16));
							Ссылка.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(17));
							Ссылка.Сумма = Читалка.GetDecimal(18);
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(20);
							Ссылка.СуммаНДС = Читалка.GetDecimal(21);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(22))[0]==1;
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(26))[0]==1;
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(30);
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(31);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПоступлениеДопРасходов ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld9244RRef [ВалютаДокумента]
					,_Fld9245RRef [ВидОперации]
					,_Fld9246RRef [ДоговорКонтрагента]
					,_Fld9247 [Комментарий]
					,_Fld9248RRef [Контрагент]
					,_Fld9249 [КратностьВзаиморасчетов]
					,_Fld9250 [КурсВзаиморасчетов]
					,_Fld9251RRef [Организация]
					,_Fld9252 [ОтражатьВУправленческомУчете]
					,_Fld9253 [ОтражатьВБухгалтерскомУчете]
					,_Fld9254 [ОтражатьВНалоговомУчете]
					,_Fld9255RRef [Подразделение]
					,_Fld9257 [Содержание]
					,_Fld9258RRef [СпособРаспределения]
					,_Fld9259RRef [СтавкаНДС]
					,_Fld9260 [Сумма]
					,_Fld9261 [СуммаВключаетНДС]
					,_Fld9262 [СуммаДокумента]
					,_Fld9263 [СуммаНДС]
					,_Fld9264 [УчитыватьНДС]
					,_Fld9265RRef [Ответственный]
					,_Fld9266RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld9267RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld9268 [НДСВключенВСтоимость]
					,_Fld9256_TYPE [Сделка_Тип],_Fld9256_RRRef [Сделка],_Fld9256_RTRef [Сделка_Вид]
					,_Fld9270 [ДатаВходящегоДокумента]
					,_Fld9269 [НомерВходящегоДокумента]
					From _Document400(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПоступлениеДопРасходов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПоступлениеДопРасходов();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(11))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Ссылка.Содержание = Читалка.GetString(15);
							Ссылка.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(16));
							Ссылка.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(17));
							Ссылка.Сумма = Читалка.GetDecimal(18);
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(20);
							Ссылка.СуммаНДС = Читалка.GetDecimal(21);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(22))[0]==1;
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(26))[0]==1;
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(30);
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(31);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПоступлениеДопРасходов ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld9244RRef [ВалютаДокумента]
					,_Fld9245RRef [ВидОперации]
					,_Fld9246RRef [ДоговорКонтрагента]
					,_Fld9247 [Комментарий]
					,_Fld9248RRef [Контрагент]
					,_Fld9249 [КратностьВзаиморасчетов]
					,_Fld9250 [КурсВзаиморасчетов]
					,_Fld9251RRef [Организация]
					,_Fld9252 [ОтражатьВУправленческомУчете]
					,_Fld9253 [ОтражатьВБухгалтерскомУчете]
					,_Fld9254 [ОтражатьВНалоговомУчете]
					,_Fld9255RRef [Подразделение]
					,_Fld9257 [Содержание]
					,_Fld9258RRef [СпособРаспределения]
					,_Fld9259RRef [СтавкаНДС]
					,_Fld9260 [Сумма]
					,_Fld9261 [СуммаВключаетНДС]
					,_Fld9262 [СуммаДокумента]
					,_Fld9263 [СуммаНДС]
					,_Fld9264 [УчитыватьНДС]
					,_Fld9265RRef [Ответственный]
					,_Fld9266RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld9267RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld9268 [НДСВключенВСтоимость]
					,_Fld9256_TYPE [Сделка_Тип],_Fld9256_RRRef [Сделка],_Fld9256_RTRef [Сделка_Вид]
					,_Fld9270 [ДатаВходящегоДокумента]
					,_Fld9269 [НомерВходящегоДокумента]
					From _Document400(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПоступлениеДопРасходов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПоступлениеДопРасходов();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(11))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Ссылка.Содержание = Читалка.GetString(15);
							Ссылка.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(16));
							Ссылка.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(17));
							Ссылка.Сумма = Читалка.GetDecimal(18);
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(20);
							Ссылка.СуммаНДС = Читалка.GetDecimal(21);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(22))[0]==1;
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(26))[0]==1;
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(30);
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(31);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПоступлениеДопРасходов СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld9244RRef [ВалютаДокумента]
					,_Fld9245RRef [ВидОперации]
					,_Fld9246RRef [ДоговорКонтрагента]
					,_Fld9247 [Комментарий]
					,_Fld9248RRef [Контрагент]
					,_Fld9249 [КратностьВзаиморасчетов]
					,_Fld9250 [КурсВзаиморасчетов]
					,_Fld9251RRef [Организация]
					,_Fld9252 [ОтражатьВУправленческомУчете]
					,_Fld9253 [ОтражатьВБухгалтерскомУчете]
					,_Fld9254 [ОтражатьВНалоговомУчете]
					,_Fld9255RRef [Подразделение]
					,_Fld9257 [Содержание]
					,_Fld9258RRef [СпособРаспределения]
					,_Fld9259RRef [СтавкаНДС]
					,_Fld9260 [Сумма]
					,_Fld9261 [СуммаВключаетНДС]
					,_Fld9262 [СуммаДокумента]
					,_Fld9263 [СуммаНДС]
					,_Fld9264 [УчитыватьНДС]
					,_Fld9265RRef [Ответственный]
					,_Fld9266RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld9267RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld9268 [НДСВключенВСтоимость]
					,_Fld9256_TYPE [Сделка_Тип],_Fld9256_RRRef [Сделка],_Fld9256_RTRef [Сделка_Вид]
					,_Fld9270 [ДатаВходящегоДокумента]
					,_Fld9269 [НомерВходящегоДокумента]
					From _Document400(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПоступлениеДопРасходов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПоступлениеДопРасходов();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(11))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Ссылка.Содержание = Читалка.GetString(15);
							Ссылка.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(16));
							Ссылка.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(17));
							Ссылка.Сумма = Читалка.GetDecimal(18);
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(20);
							Ссылка.СуммаНДС = Читалка.GetDecimal(21);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(22))[0]==1;
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(26))[0]==1;
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(30);
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(31);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПоступлениеДопРасходов СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld9244RRef [ВалютаДокумента]
					,_Fld9245RRef [ВидОперации]
					,_Fld9246RRef [ДоговорКонтрагента]
					,_Fld9247 [Комментарий]
					,_Fld9248RRef [Контрагент]
					,_Fld9249 [КратностьВзаиморасчетов]
					,_Fld9250 [КурсВзаиморасчетов]
					,_Fld9251RRef [Организация]
					,_Fld9252 [ОтражатьВУправленческомУчете]
					,_Fld9253 [ОтражатьВБухгалтерскомУчете]
					,_Fld9254 [ОтражатьВНалоговомУчете]
					,_Fld9255RRef [Подразделение]
					,_Fld9257 [Содержание]
					,_Fld9258RRef [СпособРаспределения]
					,_Fld9259RRef [СтавкаНДС]
					,_Fld9260 [Сумма]
					,_Fld9261 [СуммаВключаетНДС]
					,_Fld9262 [СуммаДокумента]
					,_Fld9263 [СуммаНДС]
					,_Fld9264 [УчитыватьНДС]
					,_Fld9265RRef [Ответственный]
					,_Fld9266RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld9267RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld9268 [НДСВключенВСтоимость]
					,_Fld9256_TYPE [Сделка_Тип],_Fld9256_RRRef [Сделка],_Fld9256_RTRef [Сделка_Вид]
					,_Fld9270 [ДатаВходящегоДокумента]
					,_Fld9269 [НомерВходящегоДокумента]
					From _Document400(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПоступлениеДопРасходов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПоступлениеДопРасходов();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.Комментарий = Читалка.GetString(6);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(11))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Ссылка.Содержание = Читалка.GetString(15);
							Ссылка.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(16));
							Ссылка.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(17));
							Ссылка.Сумма = Читалка.GetDecimal(18);
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СуммаДокумента = Читалка.GetDecimal(20);
							Ссылка.СуммаНДС = Читалка.GetDecimal(21);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(22))[0]==1;
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(26))[0]==1;
							Ссылка.ДатаВходящегоДокумента = Читалка.GetDateTime(30);
							Ссылка.НомерВходящегоДокумента = Читалка.GetString(31);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ПоступлениеДопРасходов СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ПоступлениеДопРасходов();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.Содержание = "";
			Объект.НомерВходящегоДокумента = "";
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийПоступлениеДопРасходов.ПустаяСсылка;
			Объект.СпособРаспределения = V82.Перечисления/*Ссылка*/.СпособыРаспределенияДопРасходов.ПустаяСсылка;
			Объект.СтавкаНДС = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка;
			return Объект;
		}
	}
}