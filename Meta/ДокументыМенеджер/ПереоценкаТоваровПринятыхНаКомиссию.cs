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
	public partial class ПереоценкаТоваровПринятыхНаКомиссию:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld8261 [ОтражатьВУправленческомУчете]
					,_Fld8262 [ОтражатьВБухгалтерскомУчете]
					,_Fld8263RRef [Организация]
					,_Fld8264RRef [Склад]
					,_Fld8265RRef [ТипЦен]
					,_Fld8266RRef [ВалютаДокумента]
					,_Fld8267 [КурсВзаиморасчетов]
					,_Fld8268RRef [Контрагент]
					,_Fld8269RRef [ДоговорКонтрагента]
					,_Fld8270RRef [Подразделение]
					,_Fld8271 [Комментарий]
					,_Fld8272 [КратностьВзаиморасчетов]
					,_Fld8273RRef [Ответственный]
					,_Fld8274_TYPE [Сделка_Тип],_Fld8274_RRRef [Сделка],_Fld8274_RTRef [Сделка_Вид]
					,_Fld21820 [НомерВходящегоДокументаЭлектронногоОбмена]
					,_Fld21821 [ДатаВходящегоДокументаЭлектронногоОбмена]
					From _Document379(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.Комментарий = Читалка.GetString(13);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							Ссылка.НомерВходящегоДокументаЭлектронногоОбмена = Читалка.GetString(19);
							Ссылка.ДатаВходящегоДокументаЭлектронногоОбмена = Читалка.GetDateTime(20);
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
		
		public static ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию НайтиПоНомеру(string Номер)
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
					,_Fld8261 [ОтражатьВУправленческомУчете]
					,_Fld8262 [ОтражатьВБухгалтерскомУчете]
					,_Fld8263RRef [Организация]
					,_Fld8264RRef [Склад]
					,_Fld8265RRef [ТипЦен]
					,_Fld8266RRef [ВалютаДокумента]
					,_Fld8267 [КурсВзаиморасчетов]
					,_Fld8268RRef [Контрагент]
					,_Fld8269RRef [ДоговорКонтрагента]
					,_Fld8270RRef [Подразделение]
					,_Fld8271 [Комментарий]
					,_Fld8272 [КратностьВзаиморасчетов]
					,_Fld8273RRef [Ответственный]
					,_Fld8274_TYPE [Сделка_Тип],_Fld8274_RRRef [Сделка],_Fld8274_RTRef [Сделка_Вид]
					,_Fld21820 [НомерВходящегоДокументаЭлектронногоОбмена]
					,_Fld21821 [ДатаВходящегоДокументаЭлектронногоОбмена]
					From _Document379(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.Комментарий = Читалка.GetString(13);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							Ссылка.НомерВходящегоДокументаЭлектронногоОбмена = Читалка.GetString(19);
							Ссылка.ДатаВходящегоДокументаЭлектронногоОбмена = Читалка.GetDateTime(20);
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
		
		public static ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию Выбрать()
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
					,_Fld8261 [ОтражатьВУправленческомУчете]
					,_Fld8262 [ОтражатьВБухгалтерскомУчете]
					,_Fld8263RRef [Организация]
					,_Fld8264RRef [Склад]
					,_Fld8265RRef [ТипЦен]
					,_Fld8266RRef [ВалютаДокумента]
					,_Fld8267 [КурсВзаиморасчетов]
					,_Fld8268RRef [Контрагент]
					,_Fld8269RRef [ДоговорКонтрагента]
					,_Fld8270RRef [Подразделение]
					,_Fld8271 [Комментарий]
					,_Fld8272 [КратностьВзаиморасчетов]
					,_Fld8273RRef [Ответственный]
					,_Fld8274_TYPE [Сделка_Тип],_Fld8274_RRRef [Сделка],_Fld8274_RTRef [Сделка_Вид]
					,_Fld21820 [НомерВходящегоДокументаЭлектронногоОбмена]
					,_Fld21821 [ДатаВходящегоДокументаЭлектронногоОбмена]
					From _Document379(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.Комментарий = Читалка.GetString(13);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							Ссылка.НомерВходящегоДокументаЭлектронногоОбмена = Читалка.GetString(19);
							Ссылка.ДатаВходящегоДокументаЭлектронногоОбмена = Читалка.GetDateTime(20);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld8261 [ОтражатьВУправленческомУчете]
					,_Fld8262 [ОтражатьВБухгалтерскомУчете]
					,_Fld8263RRef [Организация]
					,_Fld8264RRef [Склад]
					,_Fld8265RRef [ТипЦен]
					,_Fld8266RRef [ВалютаДокумента]
					,_Fld8267 [КурсВзаиморасчетов]
					,_Fld8268RRef [Контрагент]
					,_Fld8269RRef [ДоговорКонтрагента]
					,_Fld8270RRef [Подразделение]
					,_Fld8271 [Комментарий]
					,_Fld8272 [КратностьВзаиморасчетов]
					,_Fld8273RRef [Ответственный]
					,_Fld8274_TYPE [Сделка_Тип],_Fld8274_RRRef [Сделка],_Fld8274_RTRef [Сделка_Вид]
					,_Fld21820 [НомерВходящегоДокументаЭлектронногоОбмена]
					,_Fld21821 [ДатаВходящегоДокументаЭлектронногоОбмена]
					From _Document379(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.Комментарий = Читалка.GetString(13);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							Ссылка.НомерВходящегоДокументаЭлектронногоОбмена = Читалка.GetString(19);
							Ссылка.ДатаВходящегоДокументаЭлектронногоОбмена = Читалка.GetDateTime(20);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld8261 [ОтражатьВУправленческомУчете]
					,_Fld8262 [ОтражатьВБухгалтерскомУчете]
					,_Fld8263RRef [Организация]
					,_Fld8264RRef [Склад]
					,_Fld8265RRef [ТипЦен]
					,_Fld8266RRef [ВалютаДокумента]
					,_Fld8267 [КурсВзаиморасчетов]
					,_Fld8268RRef [Контрагент]
					,_Fld8269RRef [ДоговорКонтрагента]
					,_Fld8270RRef [Подразделение]
					,_Fld8271 [Комментарий]
					,_Fld8272 [КратностьВзаиморасчетов]
					,_Fld8273RRef [Ответственный]
					,_Fld8274_TYPE [Сделка_Тип],_Fld8274_RRRef [Сделка],_Fld8274_RTRef [Сделка_Вид]
					,_Fld21820 [НомерВходящегоДокументаЭлектронногоОбмена]
					,_Fld21821 [ДатаВходящегоДокументаЭлектронногоОбмена]
					From _Document379(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.Комментарий = Читалка.GetString(13);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							Ссылка.НомерВходящегоДокументаЭлектронногоОбмена = Читалка.GetString(19);
							Ссылка.ДатаВходящегоДокументаЭлектронногоОбмена = Читалка.GetDateTime(20);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld8261 [ОтражатьВУправленческомУчете]
					,_Fld8262 [ОтражатьВБухгалтерскомУчете]
					,_Fld8263RRef [Организация]
					,_Fld8264RRef [Склад]
					,_Fld8265RRef [ТипЦен]
					,_Fld8266RRef [ВалютаДокумента]
					,_Fld8267 [КурсВзаиморасчетов]
					,_Fld8268RRef [Контрагент]
					,_Fld8269RRef [ДоговорКонтрагента]
					,_Fld8270RRef [Подразделение]
					,_Fld8271 [Комментарий]
					,_Fld8272 [КратностьВзаиморасчетов]
					,_Fld8273RRef [Ответственный]
					,_Fld8274_TYPE [Сделка_Тип],_Fld8274_RRRef [Сделка],_Fld8274_RTRef [Сделка_Вид]
					,_Fld21820 [НомерВходящегоДокументаЭлектронногоОбмена]
					,_Fld21821 [ДатаВходящегоДокументаЭлектронногоОбмена]
					From _Document379(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.Комментарий = Читалка.GetString(13);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							Ссылка.НомерВходящегоДокументаЭлектронногоОбмена = Читалка.GetString(19);
							Ссылка.ДатаВходящегоДокументаЭлектронногоОбмена = Читалка.GetDateTime(20);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld8261 [ОтражатьВУправленческомУчете]
					,_Fld8262 [ОтражатьВБухгалтерскомУчете]
					,_Fld8263RRef [Организация]
					,_Fld8264RRef [Склад]
					,_Fld8265RRef [ТипЦен]
					,_Fld8266RRef [ВалютаДокумента]
					,_Fld8267 [КурсВзаиморасчетов]
					,_Fld8268RRef [Контрагент]
					,_Fld8269RRef [ДоговорКонтрагента]
					,_Fld8270RRef [Подразделение]
					,_Fld8271 [Комментарий]
					,_Fld8272 [КратностьВзаиморасчетов]
					,_Fld8273RRef [Ответственный]
					,_Fld8274_TYPE [Сделка_Тип],_Fld8274_RRRef [Сделка],_Fld8274_RTRef [Сделка_Вид]
					,_Fld21820 [НомерВходящегоДокументаЭлектронногоОбмена]
					,_Fld21821 [ДатаВходящегоДокументаЭлектронногоОбмена]
					From _Document379(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ПереоценкаТоваровПринятыхНаКомиссию();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ПереоценкаТоваровПринятыхНаКомиссию();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(9);
							Ссылка.Комментарий = Читалка.GetString(13);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							Ссылка.НомерВходящегоДокументаЭлектронногоОбмена = Читалка.GetString(19);
							Ссылка.ДатаВходящегоДокументаЭлектронногоОбмена = Читалка.GetDateTime(20);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ПереоценкаТоваровПринятыхНаКомиссию СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ПереоценкаТоваровПринятыхНаКомиссию();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.НомерВходящегоДокументаЭлектронногоОбмена = "";
			return Объект;
		}
	}
}