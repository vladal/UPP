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
	public partial class ОтчетКомитентуОПродажах:ДокументСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("009e6b88-5bce-47f6-976d-ece92e210d1a");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928011959.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
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
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Организации Организация {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Валюты ВалютаДокумента {get;set;}//Валюта документа
		///<summary>
		///(Общ) Сумма в валюте документа, налоги включены согласно флагам
		///</summary>
		public decimal/*(15.2)*/ СуммаДокумента {get;set;}//Сумма документа
		///<summary>
		///(Общ)
		///</summary>
		public V82.Перечисления/*Ссылка*/.СпособыРасчетаКомиссионногоВознаграждения СпособРасчетаКомиссионногоВознаграждения {get;set;}//Способ расчета комиссионного вознаграждения
		///<summary>
		///(Общ) Сумма комиссионного вознаграждения в валюте взаиморасчетов (долга перед комиссионером за услугу по реализации товаров)
		///</summary>
		public decimal/*(15.2)*/ СуммаВознаграждения {get;set;}//Сумма вознаграждения 
		///<summary>
		///(Общ)
		///</summary>
		public V82.Перечисления/*Ссылка*/.СтавкиНДС СтавкаНДСВознаграждения {get;set;}//Ставка НДС с комиссионного вознаграждения
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Контрагенты Контрагент {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ДоговорыКонтрагентов ДоговорКонтрагента {get;set;}//Договор контрагента
		///<summary>
		///(Общ)
		///</summary>
		public object Сделка {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public decimal/*(10.4)*/ КурсВзаиморасчетов {get;set;}//Курс взаиморасчетов
		///<summary>
		///(Упр)
		///</summary>
		public V82.СправочникиСсылка.Подразделения Подразделение {get;set;}
		///<summary>
		///(Общ) Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий {get;set;}
		///<summary>
		///(Общ) Процент от прибыли или с продаж, по которому рассчитывается сумма комиссионного вознаграждения
		///</summary>
		public decimal/*(5.2)*/ ПроцентКомиссионногоВознаграждения {get;set;}//Процент комиссионного вознаграждения
		///<summary>
		///(Общ)
		///</summary>
		public decimal/*(10)*/ КратностьВзаиморасчетов {get;set;}//Кратность взаиморасчетов
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.ТипыЦенНоменклатурыКонтрагентов ТипЦен {get;set;}//Тип цен
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовСКонтрагентом {get;set;}//Счет учета расчетов с контрагентом
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаРасчетовПоАвансам {get;set;}//Счет учета расчетов по авансам
		public bool УдержатьКомиссионноеВознаграждение {get;set;}//Удержать комиссионное вознаграждение
		public V82.СправочникиСсылка.Номенклатура УслугаПоВознаграждению {get;set;}//Услуга по вознаграждению за комиссию
		///<summary>
		///(Регл)
		///</summary>
		public object СчетДоходовБУ {get;set;}//Счет доходов (БУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СчетДоходовНУ {get;set;}//Счет доходов (НУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СубконтоБУ {get;set;}//Субконто (БУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СубконтоНУ {get;set;}//Субконто (НУ)
		///<summary>
		///(Регл)
		///</summary>
		public object СчетУчетаНДСПоРеализации {get;set;}//Счет учета НДС по реализации
		public object Проект {get;set;}
		
		public ОтчетКомитентуОПродажах()
		{
		}
		
		public ОтчетКомитентуОПродажах(byte[] УникальныйИдентификатор)
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
					,_Fld7295 [ОтражатьВУправленческомУчете]
					,_Fld7296 [ОтражатьВБухгалтерскомУчете]
					,_Fld7297 [ОтражатьВНалоговомУчете]
					,_Fld7298RRef [Организация]
					,_Fld7299RRef [ВалютаДокумента]
					,_Fld7300 [СуммаДокумента]
					,_Fld7301RRef [СпособРасчетаКомиссионногоВознаграждения]
					,_Fld7302 [СуммаВознаграждения]
					,_Fld7303RRef [СтавкаНДСВознаграждения]
					,_Fld7304RRef [Контрагент]
					,_Fld7305RRef [ДоговорКонтрагента]
					,_Fld7306_TYPE [Сделка_Тип],_Fld7306_RRRef [Сделка],_Fld7306_RTRef [Сделка_Вид]
					,_Fld7307 [КурсВзаиморасчетов]
					,_Fld7308RRef [Подразделение]
					,_Fld7309 [Комментарий]
					,_Fld7310 [ПроцентКомиссионногоВознаграждения]
					,_Fld7311 [КратностьВзаиморасчетов]
					,_Fld7312RRef [ТипЦен]
					,_Fld7313RRef [Ответственный]
					,_Fld7314RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld7315RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld7317 [УдержатьКомиссионноеВознаграждение]
					,_Fld7318RRef [УслугаПоВознаграждению]
					,_Fld7319RRef [СчетДоходовБУ]
					,_Fld7320RRef [СчетДоходовНУ]
					,_Fld7321RRef [СубконтоБУ]
					,_Fld7322RRef [СубконтоНУ]
					,_Fld7323RRef [СчетУчетаНДСПоРеализации]
					,_Fld7324_TYPE [Проект_Тип],_Fld7324_RRRef [Проект],_Fld7324_RTRef [Проект_Вид]
					From _Document355(NOLOCK)
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
							ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							СуммаДокумента = Читалка.GetDecimal(9);
							СпособРасчетаКомиссионногоВознаграждения = V82.Перечисления/*Ссылка*/.СпособыРасчетаКомиссионногоВознаграждения.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							СуммаВознаграждения = Читалка.GetDecimal(11);
							СтавкаНДСВознаграждения = V82.Перечисления/*Ссылка*/.СтавкиНДС.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							КурсВзаиморасчетов = Читалка.GetDecimal(18);
							Комментарий = Читалка.GetString(20);
							ПроцентКомиссионногоВознаграждения = Читалка.GetDecimal(21);
							КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							УдержатьКомиссионноеВознаграждение = ((byte[])Читалка.GetValue(27))[0]==1;
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
		
		public V82.ДокументыОбъект.ОтчетКомитентуОПродажах  ПолучитьОбъект()
		{
			var Объект = new V82.ДокументыОбъект.ОтчетКомитентуОПродажах();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Номер = Номер;
			Объект.ОтражатьВУправленческомУчете = ОтражатьВУправленческомУчете;
			Объект.ОтражатьВБухгалтерскомУчете = ОтражатьВБухгалтерскомУчете;
			Объект.ОтражатьВНалоговомУчете = ОтражатьВНалоговомУчете;
			Объект.Организация = Организация;
			Объект.ВалютаДокумента = ВалютаДокумента;
			Объект.СуммаДокумента = СуммаДокумента;
			Объект.СпособРасчетаКомиссионногоВознаграждения = СпособРасчетаКомиссионногоВознаграждения;
			Объект.СуммаВознаграждения = СуммаВознаграждения;
			Объект.СтавкаНДСВознаграждения = СтавкаНДСВознаграждения;
			Объект.Контрагент = Контрагент;
			Объект.ДоговорКонтрагента = ДоговорКонтрагента;
			Объект.Сделка = Сделка;
			Объект.КурсВзаиморасчетов = КурсВзаиморасчетов;
			Объект.Подразделение = Подразделение;
			Объект.Комментарий = Комментарий;
			Объект.ПроцентКомиссионногоВознаграждения = ПроцентКомиссионногоВознаграждения;
			Объект.КратностьВзаиморасчетов = КратностьВзаиморасчетов;
			Объект.ТипЦен = ТипЦен;
			Объект.Ответственный = Ответственный;
			Объект.СчетУчетаРасчетовСКонтрагентом = СчетУчетаРасчетовСКонтрагентом;
			Объект.СчетУчетаРасчетовПоАвансам = СчетУчетаРасчетовПоАвансам;
			Объект.УдержатьКомиссионноеВознаграждение = УдержатьКомиссионноеВознаграждение;
			Объект.УслугаПоВознаграждению = УслугаПоВознаграждению;
			Объект.СчетДоходовБУ = СчетДоходовБУ;
			Объект.СчетДоходовНУ = СчетДоходовНУ;
			Объект.СубконтоБУ = СубконтоБУ;
			Объект.СубконтоНУ = СубконтоНУ;
			Объект.СчетУчетаНДСПоРеализации = СчетУчетаНДСПоРеализации;
			Объект.Проект = Проект;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.ДокументыСсылка.ОтчетКомитентуОПродажах ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.ДокументыСсылка.ОтчетКомитентуОПродажах)Кэш[УИ];
			}
			var Ссылка = new V82.ДокументыСсылка.ОтчетКомитентуОПродажах(УникальныйИдентификатор);
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