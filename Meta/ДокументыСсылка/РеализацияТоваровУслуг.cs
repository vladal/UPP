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
	public partial class РеализацияТоваровУслуг:ДокументСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("6709bdcb-b7c6-4f18-823d-d1b66c0ffbd0");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928012029.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
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
		public V82.СправочникиСсылка.Организации Организация {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.БанковскиеСчета БанковскийСчетОрганизации {get;set;}//Банковский счет организации
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Валюты ВалютаДокумента {get;set;}//Валюта документа
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Контрагент {get;set;}
		///<summary>
		///(Упр)
		///</summary>
		public V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров ВидПередачи {get;set;}//Вид передачи
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Грузоотправитель {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Грузополучатель {get;set;}
		public V82.СправочникиСсылка.ИнформационныеКарты ДисконтнаяКарта {get;set;}//Дисконтная карта
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ДоговорыКонтрагентов ДоговорКонтрагента {get;set;}//Договор контрагента
		public string/*(0)*/ АдресДоставки {get;set;}//Адрес доставки
		///<summary>
		///(Общ) Сумма в валюте документа, налоги включены согласно флагам
		///</summary>
		public decimal/*(15.2)*/ СуммаДокумента {get;set;}//Сумма документа
		///<summary>
		///(Общ)
		///</summary>
		public decimal/*(10)*/ КратностьВзаиморасчетов {get;set;}//Кратность взаиморасчетов
		///<summary>
		///(Общ)
		///</summary>
		public decimal/*(10.4)*/ КурсВзаиморасчетов {get;set;}//Курс взаиморасчетов
		///<summary>
		///(Общ) Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий {get;set;}
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
		public object Проект {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public object Сделка {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Склады Склад {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public bool СуммаВключаетНДС {get;set;}//Сумма включает НДС
		public V82.Перечисления/*Ссылка*/.ВидыОперацийРеализацияТоваров ВидОперации {get;set;}//Вид операции
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаДоходовПоТареБУ {get;set;}//Счет учета доходов по таре (БУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаДоходовПоТареНУ {get;set;}//Счет учета доходов по таре (НУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасходовПоТареБУ {get;set;}//Счет учета расходов по таре (БУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасходовПоТареНУ {get;set;}//Счет учета расходов по таре (НУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовПоАвансам {get;set;}//Счет учета расчетов по авансам
		public V82.СправочникиСсылка.ПрочиеДоходыИРасходы СтатьяПрочихДоходовРасходовПоТаре {get;set;}//Статья прочих доходов расходов по таре
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовПоТаре {get;set;}//Счет учета расчетов по таре
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
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ФизическиеЛица ОтпускРазрешил {get;set;}//Отпуск товара разрешил
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ФизическиеЛица ОтпускПроизвел {get;set;}//Отпуск товара произвел
		///<summary>
		///(Общ)
		///</summary>
		public string/*(15)*/ ДоверенностьНомер {get;set;}//Номер доверенности
		///<summary>
		///(Общ)
		///</summary>
		public DateTime ДоверенностьДата {get;set;}//Дата доверенности
		///<summary>
		///(Общ)
		///</summary>
		public string/*(0)*/ ДоверенностьВыдана {get;set;}//Организация выдавшая доверенность
		///<summary>
		///(Общ)
		///</summary>
		public string/*(0)*/ ДоверенностьЧерезКого {get;set;}//Сотрудник организации на которого выдана доверенность
		///<summary>
		///(Общ)
		///</summary>
		public bool ОтключитьКонтрольВзаиморасчетов {get;set;}//Отключить контроль взаиморасчетов
		public V82.СправочникиСсылка.УсловияПродаж УсловиеПродаж {get;set;}//Условие продаж
		public string/*(0)*/ ДополнениеКАдресуДоставки {get;set;}//Дополнение к адресу доставки
		public V82.СправочникиСсылка.ФизическиеЛица ГлавныйБухгалтер {get;set;}//Главный бухгалтер
		public string/*(50)*/ ЗаГлавногоБухгалтераПоПриказу {get;set;}//За главного бухгалтера по приказу
		public string/*(50)*/ ЗаРуководителяПоПриказу {get;set;}//За руководителя по приказу
		
		public РеализацияТоваровУслуг()
		{
		}
		
		public РеализацияТоваровУслуг(byte[] УникальныйИдентификатор)
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
					,_Fld10817RRef [Организация]
					,_Fld10805RRef [БанковскийСчетОрганизации]
					,_Fld10806RRef [ВалютаДокумента]
					,_Fld10814RRef [Контрагент]
					,_Fld10808RRef [ВидПередачи]
					,_Fld10809RRef [Грузоотправитель]
					,_Fld10810RRef [Грузополучатель]
					,_Fld10811RRef [ДисконтнаяКарта]
					,_Fld10812RRef [ДоговорКонтрагента]
					,_Fld10804 [АдресДоставки]
					,_Fld10827 [СуммаДокумента]
					,_Fld10815 [КратностьВзаиморасчетов]
					,_Fld10816 [КурсВзаиморасчетов]
					,_Fld10813 [Комментарий]
					,_Fld10818RRef [Ответственный]
					,_Fld10819 [ОтражатьВБухгалтерскомУчете]
					,_Fld10820 [ОтражатьВНалоговомУчете]
					,_Fld10821 [ОтражатьВУправленческомУчете]
					,_Fld10822RRef [Подразделение]
					,_Fld10823_TYPE [Проект_Тип],_Fld10823_RRRef [Проект],_Fld10823_RTRef [Проект_Вид]
					,_Fld10824_TYPE [Сделка_Тип],_Fld10824_RRRef [Сделка],_Fld10824_RTRef [Сделка_Вид]
					,_Fld10825RRef [Склад]
					,_Fld10826 [СуммаВключаетНДС]
					,_Fld10807RRef [ВидОперации]
					,_Fld10834RRef [СчетУчетаДоходовПоТареБУ]
					,_Fld10835RRef [СчетУчетаДоходовПоТареНУ]
					,_Fld10836RRef [СчетУчетаРасходовПоТареБУ]
					,_Fld10837RRef [СчетУчетаРасходовПоТареНУ]
					,_Fld10828RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld10833RRef [СтатьяПрочихДоходовРасходовПоТаре]
					,_Fld10829RRef [СчетУчетаРасчетовПоТаре]
					,_Fld10830RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld10831RRef [ТипЦен]
					,_Fld10832 [УчитыватьНДС]
					,_Fld10838RRef [ОтпускРазрешил]
					,_Fld10839RRef [ОтпускПроизвел]
					,_Fld10840 [ДоверенностьНомер]
					,_Fld10841 [ДоверенностьДата]
					,_Fld10842 [ДоверенностьВыдана]
					,_Fld10843 [ДоверенностьЧерезКого]
					,_Fld10844 [ОтключитьКонтрольВзаиморасчетов]
					,_Fld10845RRef [УсловиеПродаж]
					,_Fld10846 [ДополнениеКАдресуДоставки]
					,_Fld27272RRef [ГлавныйБухгалтер]
					,_Fld27273 [ЗаГлавногоБухгалтераПоПриказу]
					,_Fld27274 [ЗаРуководителяПоПриказу]
					From _Document430(NOLOCK)
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
							ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							АдресДоставки = Читалка.GetString(13);
							СуммаДокумента = Читалка.GetDecimal(14);
							КратностьВзаиморасчетов = Читалка.GetDecimal(15);
							КурсВзаиморасчетов = Читалка.GetDecimal(16);
							Комментарий = Читалка.GetString(17);
							ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(19))[0]==1;
							ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(20))[0]==1;
							ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(21))[0]==1;
							СуммаВключаетНДС = ((byte[])Читалка.GetValue(30))[0]==1;
							ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРеализацияТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(31));
							УчитыватьНДС = ((byte[])Читалка.GetValue(41))[0]==1;
							ДоверенностьНомер = Читалка.GetString(44);
							ДоверенностьДата = Читалка.GetDateTime(45);
							ДоверенностьВыдана = Читалка.GetString(46);
							ДоверенностьЧерезКого = Читалка.GetString(47);
							ОтключитьКонтрольВзаиморасчетов = ((byte[])Читалка.GetValue(48))[0]==1;
							ДополнениеКАдресуДоставки = Читалка.GetString(50);
							ЗаГлавногоБухгалтераПоПриказу = Читалка.GetString(52);
							ЗаРуководителяПоПриказу = Читалка.GetString(53);
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
		
		public V82.ДокументыОбъект.РеализацияТоваровУслуг  ПолучитьОбъект()
		{
			var Объект = new V82.ДокументыОбъект.РеализацияТоваровУслуг();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Номер = Номер;
			Объект.Организация = Организация;
			Объект.БанковскийСчетОрганизации = БанковскийСчетОрганизации;
			Объект.ВалютаДокумента = ВалютаДокумента;
			Объект.Контрагент = Контрагент;
			Объект.ВидПередачи = ВидПередачи;
			Объект.Грузоотправитель = Грузоотправитель;
			Объект.Грузополучатель = Грузополучатель;
			Объект.ДисконтнаяКарта = ДисконтнаяКарта;
			Объект.ДоговорКонтрагента = ДоговорКонтрагента;
			Объект.АдресДоставки = АдресДоставки;
			Объект.СуммаДокумента = СуммаДокумента;
			Объект.КратностьВзаиморасчетов = КратностьВзаиморасчетов;
			Объект.КурсВзаиморасчетов = КурсВзаиморасчетов;
			Объект.Комментарий = Комментарий;
			Объект.Ответственный = Ответственный;
			Объект.ОтражатьВБухгалтерскомУчете = ОтражатьВБухгалтерскомУчете;
			Объект.ОтражатьВНалоговомУчете = ОтражатьВНалоговомУчете;
			Объект.ОтражатьВУправленческомУчете = ОтражатьВУправленческомУчете;
			Объект.Подразделение = Подразделение;
			Объект.Проект = Проект;
			Объект.Сделка = Сделка;
			Объект.Склад = Склад;
			Объект.СуммаВключаетНДС = СуммаВключаетНДС;
			Объект.ВидОперации = ВидОперации;
			Объект.СчетУчетаДоходовПоТареБУ = СчетУчетаДоходовПоТареБУ;
			Объект.СчетУчетаДоходовПоТареНУ = СчетУчетаДоходовПоТареНУ;
			Объект.СчетУчетаРасходовПоТареБУ = СчетУчетаРасходовПоТареБУ;
			Объект.СчетУчетаРасходовПоТареНУ = СчетУчетаРасходовПоТареНУ;
			Объект.СчетУчетаРасчетовПоАвансам = СчетУчетаРасчетовПоАвансам;
			Объект.СтатьяПрочихДоходовРасходовПоТаре = СтатьяПрочихДоходовРасходовПоТаре;
			Объект.СчетУчетаРасчетовПоТаре = СчетУчетаРасчетовПоТаре;
			Объект.СчетУчетаРасчетовСКонтрагентом = СчетУчетаРасчетовСКонтрагентом;
			Объект.ТипЦен = ТипЦен;
			Объект.УчитыватьНДС = УчитыватьНДС;
			Объект.ОтпускРазрешил = ОтпускРазрешил;
			Объект.ОтпускПроизвел = ОтпускПроизвел;
			Объект.ДоверенностьНомер = ДоверенностьНомер;
			Объект.ДоверенностьДата = ДоверенностьДата;
			Объект.ДоверенностьВыдана = ДоверенностьВыдана;
			Объект.ДоверенностьЧерезКого = ДоверенностьЧерезКого;
			Объект.ОтключитьКонтрольВзаиморасчетов = ОтключитьКонтрольВзаиморасчетов;
			Объект.УсловиеПродаж = УсловиеПродаж;
			Объект.ДополнениеКАдресуДоставки = ДополнениеКАдресуДоставки;
			Объект.ГлавныйБухгалтер = ГлавныйБухгалтер;
			Объект.ЗаГлавногоБухгалтераПоПриказу = ЗаГлавногоБухгалтераПоПриказу;
			Объект.ЗаРуководителяПоПриказу = ЗаРуководителяПоПриказу;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.ДокументыСсылка.РеализацияТоваровУслуг ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.ДокументыСсылка.РеализацияТоваровУслуг)Кэш[УИ];
			}
			var Ссылка = new V82.ДокументыСсылка.РеализацияТоваровУслуг(УникальныйИдентификатор);
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