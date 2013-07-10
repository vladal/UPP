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
	///<summary>
	///(Общ)
	///</summary>
	[ProtoContract]
	[DataContract]
	public partial class РеализацияУслугПоПереработке:ДокументСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("3cc3c456-6fdf-4094-86cb-cdf5acc9ae17");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928011943.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
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
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Валюты ВалютаДокумента {get;set;}//Валюта документа
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ДоговорыКонтрагентов ДоговорКонтрагента {get;set;}//Договор контрагента
		///<summary>
		///(Общ) Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Контрагент {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public decimal/*(10)*/ КратностьВзаиморасчетов {get;set;}//Кратность взаиморасчетов
		///<summary>
		///(Общ)
		///</summary>
		public decimal/*(10.4)*/ КурсВзаиморасчетов {get;set;}//Курс взаиморасчетов
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Организации Организация {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public bool ОтражатьВБухгалтерскомУчете {get;set;}//Отражать в бухгалтерском учете
		///<summary>
		///(Общ)
		///</summary>
		public bool ОтражатьВНалоговомУчете {get;set;}//Отражать в налоговом учете
		///<summary>
		///(Общ)
		///</summary>
		public bool ОтражатьВУправленческомУчете {get;set;}//Отражать в управленческом учете
		///<summary>
		///(Упр)
		///</summary>
		public V82.СправочникиСсылка.Подразделения Подразделение {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public bool СуммаВключаетНДС {get;set;}//Сумма включает НДС
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовПоАвансам {get;set;}//Счет учета расчетов по авансам
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовСКонтрагентом {get;set;}//Счет учета расчетов с контрагентом
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ТипыЦенНоменклатуры ТипЦен {get;set;}//Тип цен
		///<summary>
		///(Общ)
		///</summary>
		public bool УчитыватьНДС {get;set;}//Учитывать НДС
		///<summary>
		///(Общ) Сумма в валюте документа, налоги включены согласно флагам
		///</summary>
		public decimal/*(15.2)*/ СуммаДокумента {get;set;}//Сумма документа
		///<summary>
		///(Общ)
		///</summary>
		public V82.ДокументыСсылка.ЗаказПокупателя Сделка {get;set;}//Заказ
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Грузополучатель {get;set;}
		public object Проект {get;set;}
		public V82.СправочникиСсылка.ФизическиеЛица Исполнитель {get;set;}
		public string/*(50)*/ ИсполнительПоПриказу {get;set;}//Исполнитель по приказу
		
		public РеализацияУслугПоПереработке()
		{
		}
		
		public РеализацияУслугПоПереработке(byte[] УникальныйИдентификатор)
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
					,_Fld10961RRef [ВалютаДокумента]
					,_Fld10962RRef [ДоговорКонтрагента]
					,_Fld10963 [Комментарий]
					,_Fld10964RRef [Контрагент]
					,_Fld10965 [КратностьВзаиморасчетов]
					,_Fld10966 [КурсВзаиморасчетов]
					,_Fld10967RRef [Организация]
					,_Fld10968RRef [Ответственный]
					,_Fld10969 [ОтражатьВБухгалтерскомУчете]
					,_Fld10970 [ОтражатьВНалоговомУчете]
					,_Fld10971 [ОтражатьВУправленческомУчете]
					,_Fld10972RRef [Подразделение]
					,_Fld10974 [СуммаВключаетНДС]
					,_Fld10976RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld10977RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld10978RRef [ТипЦен]
					,_Fld10979 [УчитыватьНДС]
					,_Fld10975 [СуммаДокумента]
					,_Fld10973RRef [Сделка]
					,_Fld10980RRef [Грузополучатель]
					,_Fld10981_TYPE [Проект_Тип],_Fld10981_RRRef [Проект],_Fld10981_RTRef [Проект_Вид]
					,_Fld27275RRef [Исполнитель]
					,_Fld27276 [ИсполнительПоПриказу]
					From _Document431(NOLOCK)
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
							Комментарий = Читалка.GetString(6);
							КратностьВзаиморасчетов = Читалка.GetDecimal(8);
							КурсВзаиморасчетов = Читалка.GetDecimal(9);
							ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(14))[0]==1;
							СуммаВключаетНДС = ((byte[])Читалка.GetValue(16))[0]==1;
							УчитыватьНДС = ((byte[])Читалка.GetValue(20))[0]==1;
							СуммаДокумента = Читалка.GetDecimal(21);
							Сделка = new V82.ДокументыСсылка.ЗаказПокупателя((byte[])Читалка.GetValue(22));
							ИсполнительПоПриказу = Читалка.GetString(28);
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
		
		public V82.ДокументыОбъект.РеализацияУслугПоПереработке  ПолучитьОбъект()
		{
			var Объект = new V82.ДокументыОбъект.РеализацияУслугПоПереработке();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Номер = Номер;
			Объект.ВалютаДокумента = ВалютаДокумента;
			Объект.ДоговорКонтрагента = ДоговорКонтрагента;
			Объект.Комментарий = Комментарий;
			Объект.Контрагент = Контрагент;
			Объект.КратностьВзаиморасчетов = КратностьВзаиморасчетов;
			Объект.КурсВзаиморасчетов = КурсВзаиморасчетов;
			Объект.Организация = Организация;
			Объект.Ответственный = Ответственный;
			Объект.ОтражатьВБухгалтерскомУчете = ОтражатьВБухгалтерскомУчете;
			Объект.ОтражатьВНалоговомУчете = ОтражатьВНалоговомУчете;
			Объект.ОтражатьВУправленческомУчете = ОтражатьВУправленческомУчете;
			Объект.Подразделение = Подразделение;
			Объект.СуммаВключаетНДС = СуммаВключаетНДС;
			Объект.СчетУчетаРасчетовПоАвансам = СчетУчетаРасчетовПоАвансам;
			Объект.СчетУчетаРасчетовСКонтрагентом = СчетУчетаРасчетовСКонтрагентом;
			Объект.ТипЦен = ТипЦен;
			Объект.УчитыватьНДС = УчитыватьНДС;
			Объект.СуммаДокумента = СуммаДокумента;
			Объект.Сделка = Сделка;
			Объект.Грузополучатель = Грузополучатель;
			Объект.Проект = Проект;
			Объект.Исполнитель = Исполнитель;
			Объект.ИсполнительПоПриказу = ИсполнительПоПриказу;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.ДокументыСсылка.РеализацияУслугПоПереработке ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.ДокументыСсылка.РеализацияУслугПоПереработке)Кэш[УИ];
			}
			var Ссылка = new V82.ДокументыСсылка.РеализацияУслугПоПереработке(УникальныйИдентификатор);
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