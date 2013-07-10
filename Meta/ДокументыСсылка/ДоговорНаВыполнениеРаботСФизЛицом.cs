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
	///(Регл)
	///</summary>
	[ProtoContract]
	[DataContract]
	public partial class ДоговорНаВыполнениеРаботСФизЛицом:ДокументСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("48773c0b-9b62-4a44-8cc4-02e2f5c9ab4a");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928012032.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
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
		public V82.СправочникиСсылка.СотрудникиОрганизаций Сотрудник {get;set;}
		public V82.СправочникиСсылка.ФизическиеЛица ФизЛицо {get;set;}//Физическое лицо
		///<summary>
		///(Регл)
		///</summary>
		public V82.СправочникиСсылка.Организации Организация {get;set;}
		public V82.СправочникиСсылка.Валюты ВалютаДокумента {get;set;}//Валюта документа
		///<summary>
		///Сумма в валюте документа
		///</summary>
		public decimal/*(15.2)*/ СуммаЗаРаботу {get;set;}//Сумма за работу
		public object ВидРасчета {get;set;}//Вид расчета
		///<summary>
		///(Общ) Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		public object ВидДоговора {get;set;}//Вид договора
		public V82.Перечисления/*Ссылка*/.ВидыАвторскогоДоговора ВидАвторскогоДоговора {get;set;}//Вид авторского договора
		public DateTime ДатаНачала {get;set;}//Дата начала
		public DateTime ДатаОкончания {get;set;}//Дата окончания
		public V82.СправочникиСсылка.ПодразделенияОрганизаций ПодразделениеОрганизации {get;set;}//Подразделение организации
		public V82.Перечисления/*Ссылка*/.ХарактерВыплатыПоДоговору ХарактерОплаты {get;set;}//Характер оплаты
		public V82.Перечисления/*Ссылка*/.ОтнесениеРасходовКДеятельностиЕНВД ОтнесениеРасходовКДеятельностиЕНВД {get;set;}//Отнесение расходов к деятельности ЕНВД
		public V82.СправочникиСсылка.СпособыОтраженияЗарплатыВРеглУчете СпособОтраженияВБухучете {get;set;}//Способ отражения в бухучете
		public V82.СправочникиСсылка.ВычетыНДФЛ КодВычета {get;set;}//Код вычета
		public bool ЗаключенСоСтудентомРаботающимВСтудотряде {get;set;}//Заключен со студентом работающим в студотряде
		
		public ДоговорНаВыполнениеРаботСФизЛицом()
		{
		}
		
		public ДоговорНаВыполнениеРаботСФизЛицом(byte[] УникальныйИдентификатор)
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
					,_Fld21426RRef [Сотрудник]
					,_Fld4198RRef [ФизЛицо]
					,_Fld4199RRef [Организация]
					,_Fld4200RRef [ВалютаДокумента]
					,_Fld4201 [СуммаЗаРаботу]
					,_Fld4202RRef [ВидРасчета]
					,_Fld4203 [Комментарий]
					,_Fld4204RRef [Ответственный]
					,_Fld4205_TYPE [ВидДоговора_Тип],_Fld4205_RRRef [ВидДоговора],_Fld4205_RTRef [ВидДоговора_Вид]
					,_Fld26724RRef [ВидАвторскогоДоговора]
					,_Fld4206 [ДатаНачала]
					,_Fld4207 [ДатаОкончания]
					,_Fld4208RRef [ПодразделениеОрганизации]
					,_Fld4209RRef [ХарактерОплаты]
					,_Fld21428RRef [ОтнесениеРасходовКДеятельностиЕНВД]
					,_Fld21427RRef [СпособОтраженияВБухучете]
					,_Fld4210RRef [КодВычета]
					,_Fld26725 [ЗаключенСоСтудентомРаботающимВСтудотряде]
					From _Document252(NOLOCK)
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
							СуммаЗаРаботу = Читалка.GetDecimal(8);
							Комментарий = Читалка.GetString(10);
							ВидАвторскогоДоговора = V82.Перечисления/*Ссылка*/.ВидыАвторскогоДоговора.ПустаяСсылка.Получить((byte[])Читалка.GetValue(15));
							ДатаНачала = Читалка.GetDateTime(16);
							ДатаОкончания = Читалка.GetDateTime(17);
							ХарактерОплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыПоДоговору.ПустаяСсылка.Получить((byte[])Читалка.GetValue(19));
							ОтнесениеРасходовКДеятельностиЕНВД = V82.Перечисления/*Ссылка*/.ОтнесениеРасходовКДеятельностиЕНВД.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							ЗаключенСоСтудентомРаботающимВСтудотряде = ((byte[])Читалка.GetValue(23))[0]==1;
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
		
		public V82.ДокументыОбъект.ДоговорНаВыполнениеРаботСФизЛицом  ПолучитьОбъект()
		{
			var Объект = new V82.ДокументыОбъект.ДоговорНаВыполнениеРаботСФизЛицом();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Номер = Номер;
			Объект.Сотрудник = Сотрудник;
			Объект.ФизЛицо = ФизЛицо;
			Объект.Организация = Организация;
			Объект.ВалютаДокумента = ВалютаДокумента;
			Объект.СуммаЗаРаботу = СуммаЗаРаботу;
			Объект.ВидРасчета = ВидРасчета;
			Объект.Комментарий = Комментарий;
			Объект.Ответственный = Ответственный;
			Объект.ВидДоговора = ВидДоговора;
			Объект.ВидАвторскогоДоговора = ВидАвторскогоДоговора;
			Объект.ДатаНачала = ДатаНачала;
			Объект.ДатаОкончания = ДатаОкончания;
			Объект.ПодразделениеОрганизации = ПодразделениеОрганизации;
			Объект.ХарактерОплаты = ХарактерОплаты;
			Объект.ОтнесениеРасходовКДеятельностиЕНВД = ОтнесениеРасходовКДеятельностиЕНВД;
			Объект.СпособОтраженияВБухучете = СпособОтраженияВБухучете;
			Объект.КодВычета = КодВычета;
			Объект.ЗаключенСоСтудентомРаботающимВСтудотряде = ЗаключенСоСтудентомРаботающимВСтудотряде;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.ДокументыСсылка.ДоговорНаВыполнениеРаботСФизЛицом ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.ДокументыСсылка.ДоговорНаВыполнениеРаботСФизЛицом)Кэш[УИ];
			}
			var Ссылка = new V82.ДокументыСсылка.ДоговорНаВыполнениеРаботСФизЛицом(УникальныйИдентификатор);
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