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
	public partial class ВозвратТоваровПоставщику:ДокументСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("57518a3e-6a86-4c10-b9c1-62df1680d976");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928012002.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
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
		public bool ОтражатьВУправленческомУчете {get;set;}//Отражать в управленческом учете
		///<summary>
		///(Общ)
		///</summary>
		public bool ОтражатьВБухгалтерскомУчете {get;set;}//Отражать в бухгалтерском учете
		///<summary>
		///(Общ)
		///</summary>
		public bool ОтражатьВНалоговомУчете {get;set;}//Отражать в налоговом учете
		///<summary>
		///(Упр)
		///</summary>
		public V82.СправочникиСсылка.Подразделения Подразделение {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику ВидОперации {get;set;}//Вид операции
		///<summary>
		///(Общ) Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий {get;set;}
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
		public V82.СправочникиСсылка.ДоговорыКонтрагентов ДоговорКонтрагента {get;set;}//Договор контрагента
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Контрагент {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ТипыЦенНоменклатурыКонтрагентов ТипЦен {get;set;}//Тип цен
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Валюты ВалютаДокумента {get;set;}//Валюта документа
		///<summary>
		///(Общ)
		///</summary>
		public bool УчитыватьНДС {get;set;}//Учитывать НДС
		///<summary>
		///(Общ)
		///</summary>
		public bool СуммаВключаетНДС {get;set;}//Сумма включает НДС
		///<summary>
		///(Общ)
		///</summary>
		public decimal/*(10.4)*/ КурсВзаиморасчетов {get;set;}//Курс взаиморасчетов
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
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров ВидПередачи {get;set;}//Вид передачи
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовСКонтрагентом {get;set;}//Счет учета расчетов с контрагентом
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовПоАвансам {get;set;}//Счет учета расчетов по авансам
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовПоПретензиям {get;set;}//Счет учета расчетов по претензиям
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовПоТаре {get;set;}//Счет учета расчетов по таре
		///<summary>
		///(Общ)
		///</summary>
		public bool НДСВключенВСтоимость {get;set;}//НДС включен в стоимость
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.БанковскиеСчета БанковскийСчетОрганизации {get;set;}//Банковский счет организации
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Грузоотправитель {get;set;}
		public object Проект {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Грузополучатель {get;set;}
		public object СчетУчетаДоходовБУ {get;set;}//Счет учета доходов (БУ)
		public object СчетУчетаРасходовБУ {get;set;}//Счет учета расходов (БУ)
		public object СчетУчетаДоходовНУ {get;set;}//Счет учета доходов (НУ)
		public object СчетУчетаРасходовНУ {get;set;}//Счет учета расходов (НУ)
		public V82.СправочникиСсылка.ПрочиеДоходыИРасходы СтатьяДоходовИРасходов {get;set;}//Статья доходов и расходов
		public bool ПоставщикуВыставляетсяСчетФактураНаВозврат {get;set;}//Поставщику выставляется счет-фактура на возврат
		
		public ВозвратТоваровПоставщику()
		{
		}
		
		public ВозвратТоваровПоставщику(byte[] УникальныйИдентификатор)
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
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)
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
							ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(9));
							Комментарий = Читалка.GetString(10);
							УчитыватьНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							СуммаВключаетНДС = ((byte[])Читалка.GetValue(20))[0]==1;
							КурсВзаиморасчетов = Читалка.GetDecimal(21);
							СуммаДокумента = Читалка.GetDecimal(22);
							КратностьВзаиморасчетов = Читалка.GetDecimal(23);
							ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(25));
							НДСВключенВСтоимость = ((byte[])Читалка.GetValue(30))[0]==1;
							ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(42))[0]==1;
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
		
		public V82.ДокументыОбъект.ВозвратТоваровПоставщику  ПолучитьОбъект()
		{
			var Объект = new V82.ДокументыОбъект.ВозвратТоваровПоставщику();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Номер = Номер;
			Объект.Организация = Организация;
			Объект.ОтражатьВУправленческомУчете = ОтражатьВУправленческомУчете;
			Объект.ОтражатьВБухгалтерскомУчете = ОтражатьВБухгалтерскомУчете;
			Объект.ОтражатьВНалоговомУчете = ОтражатьВНалоговомУчете;
			Объект.Подразделение = Подразделение;
			Объект.ВидОперации = ВидОперации;
			Объект.Комментарий = Комментарий;
			Объект.Сделка = Сделка;
			Объект.Склад = Склад;
			Объект.ДоговорКонтрагента = ДоговорКонтрагента;
			Объект.Контрагент = Контрагент;
			Объект.ТипЦен = ТипЦен;
			Объект.ВалютаДокумента = ВалютаДокумента;
			Объект.УчитыватьНДС = УчитыватьНДС;
			Объект.СуммаВключаетНДС = СуммаВключаетНДС;
			Объект.КурсВзаиморасчетов = КурсВзаиморасчетов;
			Объект.СуммаДокумента = СуммаДокумента;
			Объект.КратностьВзаиморасчетов = КратностьВзаиморасчетов;
			Объект.Ответственный = Ответственный;
			Объект.ВидПередачи = ВидПередачи;
			Объект.СчетУчетаРасчетовСКонтрагентом = СчетУчетаРасчетовСКонтрагентом;
			Объект.СчетУчетаРасчетовПоАвансам = СчетУчетаРасчетовПоАвансам;
			Объект.СчетУчетаРасчетовПоПретензиям = СчетУчетаРасчетовПоПретензиям;
			Объект.СчетУчетаРасчетовПоТаре = СчетУчетаРасчетовПоТаре;
			Объект.НДСВключенВСтоимость = НДСВключенВСтоимость;
			Объект.БанковскийСчетОрганизации = БанковскийСчетОрганизации;
			Объект.Грузоотправитель = Грузоотправитель;
			Объект.Проект = Проект;
			Объект.Грузополучатель = Грузополучатель;
			Объект.СчетУчетаДоходовБУ = СчетУчетаДоходовБУ;
			Объект.СчетУчетаРасходовБУ = СчетУчетаРасходовБУ;
			Объект.СчетУчетаДоходовНУ = СчетУчетаДоходовНУ;
			Объект.СчетУчетаРасходовНУ = СчетУчетаРасходовНУ;
			Объект.СтатьяДоходовИРасходов = СтатьяДоходовИРасходов;
			Объект.ПоставщикуВыставляетсяСчетФактураНаВозврат = ПоставщикуВыставляетсяСчетФактураНаВозврат;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.ДокументыСсылка.ВозвратТоваровПоставщику ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.ДокументыСсылка.ВозвратТоваровПоставщику)Кэш[УИ];
			}
			var Ссылка = new V82.ДокументыСсылка.ВозвратТоваровПоставщику(УникальныйИдентификатор);
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