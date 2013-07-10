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
	public partial class ЗаявкаНаРасходованиеСредств:ДокументСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("726538f4-e866-443e-98d2-5d21c4e4e3c6");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928012026.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
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
		public V82.Перечисления/*Ссылка*/.ВидыОперацийЗаявкиНаРасходование ВидОперации {get;set;}//Вид операции
		public DateTime ДатаРасхода {get;set;}//Дата расхода
		///<summary>
		///Подотчетник, касса ККМ
		///</summary>
		public object Получатель {get;set;}
		public object ДокументОснование {get;set;}//Документ основание
		public V82.Перечисления/*Ссылка*/.ВидыДенежныхСредств ФормаОплаты {get;set;}//Форма оплаты
		///<summary>
		///Р/с, касса 
		///</summary>
		public object БанковскийСчетКасса {get;set;}//Банковский счет касса
		public V82.СправочникиСсылка.Валюты ВалютаДокумента {get;set;}//Валюта документа
		public decimal/*(10.4)*/ КурсДокумента {get;set;}//Курс документа
		public decimal/*(10)*/ КратностьДокумента {get;set;}//Кратность документа
		///<summary>
		///Валюта, в которой подотчетник должен отчитаться за истраченные деньги
		///</summary>
		public V82.СправочникиСсылка.Валюты ВалютаВзаиморасчетовПодотчетника {get;set;}//Валюта взаиморасчетов подотчетника
		public object РасчетныйДокумент {get;set;}//Расчетный документ
		///<summary>
		///(Упр) срок погашения аванса подотчетником
		///</summary>
		public DateTime ДатаПогашенияАванса {get;set;}//Дата погашения аванса
		public decimal/*(15.2)*/ СуммаДокумента {get;set;}//Сумма документа
		public V82.СправочникиСсылка.СценарииПланирования Сценарий {get;set;}
		public V82.СправочникиСсылка.СтатьиОборотовПоБюджетам СтатьяОборотов {get;set;}//Статья оборотов
		public V82.СправочникиСсылка.Подразделения ЦФО {get;set;}
		public V82.СправочникиСсылка.Контрагенты Контрагент {get;set;}
		public object Номенклатура {get;set;}
		public V82.Перечисления/*Ссылка*/.СостоянияОбъектов Состояние {get;set;}
		public string/*(0)*/ Описание {get;set;}
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		///<summary>
		///Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий {get;set;}
		public V82.СправочникиСсылка.Организации Организация {get;set;}
		///<summary>
		///(Упр)
		///</summary>
		public bool АвтоРезервированиеПоЗаявке {get;set;}//Авторезервирование денежных средств
		///<summary>
		///(Упр)
		///</summary>
		public bool АвтоРазмещениеПоЗаявке {get;set;}//Авторазмещение по заявке
		public bool ВключатьВПлатежныйКалендарь {get;set;}//Включать в платежный календарь
		public V82.Перечисления/*Ссылка*/.ВидВыдачиДенежныхСредств ВидВыдачиДенежныхСредств {get;set;}//Вид выдачи денежных средств
		
		public ЗаявкаНаРасходованиеСредств()
		{
		}
		
		public ЗаявкаНаРасходованиеСредств(byte[] УникальныйИдентификатор)
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
					,_Fld4734RRef [ВидОперации]
					,_Fld4735 [ДатаРасхода]
					,_Fld4736_TYPE [Получатель_Тип],_Fld4736_RRRef [Получатель],_Fld4736_RTRef [Получатель_Вид]
					,_Fld4737_TYPE [ДокументОснование_Тип],_Fld4737_RRRef [ДокументОснование],_Fld4737_RTRef [ДокументОснование_Вид]
					,_Fld4738RRef [ФормаОплаты]
					,_Fld4739_TYPE [БанковскийСчетКасса_Тип],_Fld4739_RRRef [БанковскийСчетКасса],_Fld4739_RTRef [БанковскийСчетКасса_Вид]
					,_Fld4740RRef [ВалютаДокумента]
					,_Fld4741 [КурсДокумента]
					,_Fld4742 [КратностьДокумента]
					,_Fld4743RRef [ВалютаВзаиморасчетовПодотчетника]
					,_Fld4744_TYPE [РасчетныйДокумент_Тип],_Fld4744_RRRef [РасчетныйДокумент],_Fld4744_RTRef [РасчетныйДокумент_Вид]
					,_Fld4745 [ДатаПогашенияАванса]
					,_Fld4746 [СуммаДокумента]
					,_Fld4747RRef [Сценарий]
					,_Fld4748RRef [СтатьяОборотов]
					,_Fld4749RRef [ЦФО]
					,_Fld4750RRef [Контрагент]
					,_Fld4751_TYPE [Номенклатура_Тип],_Fld4751_RRRef [Номенклатура],_Fld4751_RTRef [Номенклатура_Вид]
					,_Fld4752RRef [Состояние]
					,_Fld4753 [Описание]
					,_Fld4754RRef [Ответственный]
					,_Fld4755 [Комментарий]
					,_Fld4756RRef [Организация]
					,_Fld4757 [АвтоРезервированиеПоЗаявке]
					,_Fld4758 [АвтоРазмещениеПоЗаявке]
					,_Fld4759 [ВключатьВПлатежныйКалендарь]
					,_Fld4760RRef [ВидВыдачиДенежныхСредств]
					From _Document271(NOLOCK)
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
							ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийЗаявкиНаРасходование.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							ДатаРасхода = Читалка.GetDateTime(5);
							ФормаОплаты = V82.Перечисления/*Ссылка*/.ВидыДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(12));
							КурсДокумента = Читалка.GetDecimal(17);
							КратностьДокумента = Читалка.GetDecimal(18);
							ДатаПогашенияАванса = Читалка.GetDateTime(23);
							СуммаДокумента = Читалка.GetDecimal(24);
							Состояние = V82.Перечисления/*Ссылка*/.СостоянияОбъектов.ПустаяСсылка.Получить((byte[])Читалка.GetValue(32));
							Описание = Читалка.GetString(33);
							Комментарий = Читалка.GetString(35);
							АвтоРезервированиеПоЗаявке = ((byte[])Читалка.GetValue(37))[0]==1;
							АвтоРазмещениеПоЗаявке = ((byte[])Читалка.GetValue(38))[0]==1;
							ВключатьВПлатежныйКалендарь = ((byte[])Читалка.GetValue(39))[0]==1;
							ВидВыдачиДенежныхСредств = V82.Перечисления/*Ссылка*/.ВидВыдачиДенежныхСредств.ПустаяСсылка.Получить((byte[])Читалка.GetValue(40));
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
		
		public V82.ДокументыОбъект.ЗаявкаНаРасходованиеСредств  ПолучитьОбъект()
		{
			var Объект = new V82.ДокументыОбъект.ЗаявкаНаРасходованиеСредств();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Номер = Номер;
			Объект.ВидОперации = ВидОперации;
			Объект.ДатаРасхода = ДатаРасхода;
			Объект.Получатель = Получатель;
			Объект.ДокументОснование = ДокументОснование;
			Объект.ФормаОплаты = ФормаОплаты;
			Объект.БанковскийСчетКасса = БанковскийСчетКасса;
			Объект.ВалютаДокумента = ВалютаДокумента;
			Объект.КурсДокумента = КурсДокумента;
			Объект.КратностьДокумента = КратностьДокумента;
			Объект.ВалютаВзаиморасчетовПодотчетника = ВалютаВзаиморасчетовПодотчетника;
			Объект.РасчетныйДокумент = РасчетныйДокумент;
			Объект.ДатаПогашенияАванса = ДатаПогашенияАванса;
			Объект.СуммаДокумента = СуммаДокумента;
			Объект.Сценарий = Сценарий;
			Объект.СтатьяОборотов = СтатьяОборотов;
			Объект.ЦФО = ЦФО;
			Объект.Контрагент = Контрагент;
			Объект.Номенклатура = Номенклатура;
			Объект.Состояние = Состояние;
			Объект.Описание = Описание;
			Объект.Ответственный = Ответственный;
			Объект.Комментарий = Комментарий;
			Объект.Организация = Организация;
			Объект.АвтоРезервированиеПоЗаявке = АвтоРезервированиеПоЗаявке;
			Объект.АвтоРазмещениеПоЗаявке = АвтоРазмещениеПоЗаявке;
			Объект.ВключатьВПлатежныйКалендарь = ВключатьВПлатежныйКалендарь;
			Объект.ВидВыдачиДенежныхСредств = ВидВыдачиДенежныхСредств;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.ДокументыСсылка.ЗаявкаНаРасходованиеСредств ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.ДокументыСсылка.ЗаявкаНаРасходованиеСредств)Кэш[УИ];
			}
			var Ссылка = new V82.ДокументыСсылка.ЗаявкаНаРасходованиеСредств(УникальныйИдентификатор);
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