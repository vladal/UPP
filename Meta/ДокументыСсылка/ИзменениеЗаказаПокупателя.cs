﻿
using System;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.Serialization;
using ProtoBuf;/*https://github.com/ServiceStack/ServiceStack/tree/master/lib*/
using ServiceStack.Text;/*https://github.com/ServiceStack/ServiceStack.Text*/
using V82;
using V82.ОбщиеОбъекты;
using V82.ДокументыСсылка;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.ДокументыСсылка
{
	[ProtoContract]
	[DataContract]
	public partial class ИзменениеЗаказаПокупателя:ДокументСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("85516c7d-1ce3-4f76-8888-c0ac3fd16760");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928011955.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
		public static readonly long КонтрольнаяСуммаКласса = 123;
		[DataMember]
		[ProtoMember(1)]
		public Guid Ссылка {get;set;}
		[DataMember]
		[ProtoMember(2)]
		public long Версия {get;set;}
		public string ВерсияДанных {get;set;}
		/*static хэш сумма состава и порядка реквизитов*/
		/*версия класса восстановленного из пакета*/
		public bool ПометкаУдаления {get;set;}
		public DateTime Дата {get;set;}
		public DateTime ПрефиксНомера {get;set;}
		public string/*11*/ Номер {get;set;}
		public bool Проведен {get;set;}
		public V82.ДокументыСсылка.ЗаказПокупателя ЗаказПокупателя {get;set;}//Заказ покупателя
		///<summary>
		///Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий {get;set;}
		///<summary>
		///Сумма в валюте документа, налоги включены согласно флагам
		///</summary>
		public decimal/*(15.2)*/ СуммаДокумента {get;set;}//Сумма документа
		public V82.СправочникиСсылка.ТипыЦенНоменклатуры ТипЦен {get;set;}//Тип цен
		public bool УчитыватьНДС {get;set;}//Учитывать НДС
		public bool СуммаВключаетНДС {get;set;}//Сумма включает НДС
		public object СтруктурнаяЕдиница {get;set;}//Структурная единица
		///<summary>
		///Курс валюты взаиморасчетов по договору
		///</summary>
		public decimal/*(10.4)*/ КурсВзаиморасчетов {get;set;}//Курс взаиморасчетов
		public decimal/*(10)*/ КратностьВзаиморасчетов {get;set;}//Кратность взаиморасчетов
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		public decimal/*(15.2)*/ ИтогПлановаяСебестоимость {get;set;}//Итоговая плановая себестоимость в валюте управленческого учета
		///<summary>
		///(Общ)
		///</summary>
		public bool ИспользоватьПлановуюСебестоимость {get;set;}//Использовать плановую себестоимость
		public V82.СправочникиСсылка.ИнформационныеКарты ДисконтнаяКарта {get;set;}//Дисконтная карта
		public V82.СправочникиСсылка.Контрагенты Контрагент {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ДоговорыКонтрагентов ДоговорКонтрагента {get;set;}//Договор контрагента
		public V82.СправочникиСсылка.УсловияПродаж УсловиеПродаж {get;set;}//Условие продаж
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Организации Организация {get;set;}
		///<summary>
		///(Упр)
		///</summary>
		public V82.СправочникиСсылка.Подразделения Подразделение {get;set;}
		
		public ИзменениеЗаказаПокупателя()
		{
		}
		
		public ИзменениеЗаказаПокупателя(byte[] УникальныйИдентификатор)
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
					,_Number [Номер]
					,_Fld20055RRef [ЗаказПокупателя]
					,_Fld20056 [Комментарий]
					,_Fld20057 [СуммаДокумента]
					,_Fld20058RRef [ТипЦен]
					,_Fld20059 [УчитыватьНДС]
					,_Fld20060 [СуммаВключаетНДС]
					,_Fld20061_TYPE [СтруктурнаяЕдиница_Тип],_Fld20061_RRRef [СтруктурнаяЕдиница],_Fld20061_RTRef [СтруктурнаяЕдиница_Вид]
					,_Fld20062 [КурсВзаиморасчетов]
					,_Fld20063 [КратностьВзаиморасчетов]
					,_Fld20064RRef [Ответственный]
					,_Fld20065 [ИтогПлановаяСебестоимость]
					,_Fld20066 [ИспользоватьПлановуюСебестоимость]
					,_Fld20067RRef [ДисконтнаяКарта]
					,_Fld20068RRef [Контрагент]
					,_Fld20069RRef [ДоговорКонтрагента]
					,_Fld20070RRef [УсловиеПродаж]
					,_Fld20071RRef [Организация]
					,_Fld20072RRef [Подразделение]
					From _Document19658(NOLOCK)
					Where _IDRRef=@УникальныйИдентификатор";
					Команда.Parameters.AddWithValue("УникальныйИдентификатор", УникальныйИдентификатор);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							//ToDo: Читать нужно через GetValues()
							Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Номер = Читалка.GetString(3);
							ЗаказПокупателя = new V82.ДокументыСсылка.ЗаказПокупателя((byte[])Читалка.GetValue(4));
							Комментарий = Читалка.GetString(5);
							СуммаДокумента = Читалка.GetDecimal(6);
							УчитыватьНДС = ((byte[])Читалка.GetValue(8))[0]==1;
							СуммаВключаетНДС = ((byte[])Читалка.GetValue(9))[0]==1;
							КурсВзаиморасчетов = Читалка.GetDecimal(13);
							КратностьВзаиморасчетов = Читалка.GetDecimal(14);
							ИтогПлановаяСебестоимость = Читалка.GetDecimal(16);
							ИспользоватьПлановуюСебестоимость = ((byte[])Читалка.GetValue(17))[0]==1;
							//return Ссылка;
						}
						else
						{
							//return null;
						}
					}
				}
			}
		}
		
		public V82.ДокументыОбъект.ИзменениеЗаказаПокупателя  ПолучитьОбъект()
		{
			var Объект = new V82.ДокументыОбъект.ИзменениеЗаказаПокупателя();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Номер = Номер;
			Объект.ЗаказПокупателя = ЗаказПокупателя;
			Объект.Комментарий = Комментарий;
			Объект.СуммаДокумента = СуммаДокумента;
			Объект.ТипЦен = ТипЦен;
			Объект.УчитыватьНДС = УчитыватьНДС;
			Объект.СуммаВключаетНДС = СуммаВключаетНДС;
			Объект.СтруктурнаяЕдиница = СтруктурнаяЕдиница;
			Объект.КурсВзаиморасчетов = КурсВзаиморасчетов;
			Объект.КратностьВзаиморасчетов = КратностьВзаиморасчетов;
			Объект.Ответственный = Ответственный;
			Объект.ИтогПлановаяСебестоимость = ИтогПлановаяСебестоимость;
			Объект.ИспользоватьПлановуюСебестоимость = ИспользоватьПлановуюСебестоимость;
			Объект.ДисконтнаяКарта = ДисконтнаяКарта;
			Объект.Контрагент = Контрагент;
			Объект.ДоговорКонтрагента = ДоговорКонтрагента;
			Объект.УсловиеПродаж = УсловиеПродаж;
			Объект.Организация = Организация;
			Объект.Подразделение = Подразделение;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.ДокументыСсылка.ИзменениеЗаказаПокупателя ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.ДокументыСсылка.ИзменениеЗаказаПокупателя)Кэш[УИ];
			}
			var Ссылка = new V82.ДокументыСсылка.ИзменениеЗаказаПокупателя(УникальныйИдентификатор);
			Кэш.Add(УИ, Ссылка);
			return Ссылка;
		}
		
		public void СериализацияProtoBuf(Stream Поток)
		{
			Serializer.Serialize(Поток,this);
		}
		
		public string СериализацияJson()
		{
			return this.ToJson();
		}
		
		public string СериализацияXml()
		{
			return this.ToXml();
		}
	}
}