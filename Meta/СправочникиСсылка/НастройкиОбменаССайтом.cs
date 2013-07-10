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
using V82.СправочникиСсылка;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.СправочникиСсылка
{
	[ProtoContract]
	[DataContract]
	public partial class НастройкиОбменаССайтом:СправочникСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("0c148f3d-26d7-4fdb-b823-6a8a1caf7ee7");
		public static readonly DateTime ВерсияКласса = DateTime.ParseExact("20120928012012.000", new string[] {"yyyyMMddHHmmss.fff"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
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
		public bool Предопределенный {get;set;}
		public string/*3*/ Код {get;set;}
		[DataMember(Name = "Представление")]//Проверить основное представление.
		[ProtoMember(3)]
		public string/*50*/ Наименование {get;set;}
		public bool ОбменТоварами {get;set;}//Обмен товарами
		public bool ОбменЗаказами {get;set;}//Обмен заказами
		public object УзелОбменаТоварами {get;set;}//Узел обмена товарами
		public object УзелОбменаЗаказами {get;set;}//Узел обмена заказами
		public bool ВыгружатьТолькоИзменения {get;set;}//Выгружать только изменения
		public bool ВыгружатьНаСайт {get;set;}//Выгружать на сайт
		public string/*(0)*/ КаталогВыгрузки {get;set;}//Каталог выгрузки
		public string/*(255)*/ HTTPОбменАдресСайта {get;set;}//HTTP адрес раздела сайта для обмена
		public string/*(255)*/ HTTPОбменИмяПользователя {get;set;}//HTTP обмен имя пользователя
		public string/*(255)*/ HTTPОбменПароль {get;set;}//HTTP обмен пароль
		public bool HTTPОбменПроксиИспользование {get;set;}//Использовать прокси-сервер
		public string/*(255)*/ HTTPОбменПроксиСервер {get;set;}//Имя или адрес сервера
		public decimal/*(5)*/ HTTPОбменПроксиПорт {get;set;}//Порт прокси-сервера
		public string/*(255)*/ HTTPОбменПроксиИмяПользователя {get;set;}//Имя пользователя прокси
		public string/*(255)*/ HTTPОбменПроксиПароль {get;set;}//Пароль пользователя прокси-сервера
		public V82.СправочникиСсылка.Контрагенты ГруппаДляНовыхКонтрагентов {get;set;}//Группа для новых контрагентов
		public V82.СправочникиСсылка.Номенклатура ГруппаДляНовойНоменклатуры {get;set;}//Группа для новой номенклатуры
		public V82.СправочникиСсылка.Организации Организация {get;set;}
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		public V82.СправочникиСсылка.Подразделения Подразделение {get;set;}
		public bool ЗаписыватьДокументыТекущейДатой {get;set;}//Записывать документы текущей датой
		public bool ПроводитьДокументы {get;set;}//Проводить документы
		public bool ПроводитьДокументыОперативно {get;set;}//Проводить документы оперативно
		public string/*(12)*/ СпособИдентификацииКонтрагентов {get;set;}//Способ идентификации контрагентов
		public V82.СправочникиСсылка.КлассификаторЕдиницИзмерения ЕдиницаИзмеренияНовойНоменклатуры {get;set;}//Единица измерения новой номенклатуры
		public ХранилищеЗначения СохраненныеНастройкиПостроителя {get;set;}
		public bool ВыгружатьКартинки {get;set;}//Выгружать картинки
		public string/*(0)*/ Комментарий {get;set;}
		public string/*(40)*/ РегламентноеЗадание {get;set;}//Регламентное задание
		public bool ИспользоватьРегламентныеЗадания {get;set;}//Использовать регламентные задания
		
		public НастройкиОбменаССайтом()
		{
		}
		
		public НастройкиОбменаССайтом(byte[] УникальныйИдентификатор)
			: this(УникальныйИдентификатор,0)
		{
		}
		
		public НастройкиОбменаССайтом(byte[] УникальныйИдентификатор,int Глубина)
		{
			if (Глубина>3)
			{
				return;
			}
			if (new Guid(УникальныйИдентификатор) == Guid.Empty)
			{
				return;
			}
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19768 [ОбменТоварами]
					,_Fld19769 [ОбменЗаказами]
					,_Fld19770RRef [УзелОбменаТоварами]
					,_Fld19771RRef [УзелОбменаЗаказами]
					,_Fld19772 [ВыгружатьТолькоИзменения]
					,_Fld19773 [ВыгружатьНаСайт]
					,_Fld19774 [КаталогВыгрузки]
					,_Fld19775 [HTTPОбменАдресСайта]
					,_Fld19776 [HTTPОбменИмяПользователя]
					,_Fld19777 [HTTPОбменПароль]
					,_Fld19778 [HTTPОбменПроксиИспользование]
					,_Fld19779 [HTTPОбменПроксиСервер]
					,_Fld19780 [HTTPОбменПроксиПорт]
					,_Fld19781 [HTTPОбменПроксиИмяПользователя]
					,_Fld19782 [HTTPОбменПроксиПароль]
					,_Fld19783RRef [ГруппаДляНовыхКонтрагентов]
					,_Fld19784RRef [ГруппаДляНовойНоменклатуры]
					,_Fld19785RRef [Организация]
					,_Fld19786RRef [Ответственный]
					,_Fld19787RRef [Подразделение]
					,_Fld19788 [ЗаписыватьДокументыТекущейДатой]
					,_Fld19789 [ПроводитьДокументы]
					,_Fld19790 [ПроводитьДокументыОперативно]
					,_Fld19791 [СпособИдентификацииКонтрагентов]
					,_Fld19792RRef [ЕдиницаИзмеренияНовойНоменклатуры]
					,_Fld19793 [СохраненныеНастройкиПостроителя]
					,_Fld19794 [ВыгружатьКартинки]
					,_Fld19795 [Комментарий]
					,_Fld19796 [РегламентноеЗадание]
					,_Fld19797 [ИспользоватьРегламентныеЗадания]
					From _Reference19645(NOLOCK)
					Where _IDRRef=@УникальныйИдентификатор  ";
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
							Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Код = Читалка.GetString(4);
							Наименование = Читалка.GetString(5);
							ОбменТоварами = ((byte[])Читалка.GetValue(6))[0]==1;
							ОбменЗаказами = ((byte[])Читалка.GetValue(7))[0]==1;
							ВыгружатьТолькоИзменения = ((byte[])Читалка.GetValue(10))[0]==1;
							ВыгружатьНаСайт = ((byte[])Читалка.GetValue(11))[0]==1;
							КаталогВыгрузки = Читалка.GetString(12);
							HTTPОбменАдресСайта = Читалка.GetString(13);
							HTTPОбменИмяПользователя = Читалка.GetString(14);
							HTTPОбменПароль = Читалка.GetString(15);
							HTTPОбменПроксиИспользование = ((byte[])Читалка.GetValue(16))[0]==1;
							HTTPОбменПроксиСервер = Читалка.GetString(17);
							HTTPОбменПроксиПорт = Читалка.GetDecimal(18);
							HTTPОбменПроксиИмяПользователя = Читалка.GetString(19);
							HTTPОбменПроксиПароль = Читалка.GetString(20);
							ГруппаДляНовыхКонтрагентов = new V82.СправочникиСсылка.Контрагенты((byte[])Читалка.GetValue(21),Глубина+1);
							ГруппаДляНовойНоменклатуры = new V82.СправочникиСсылка.Номенклатура((byte[])Читалка.GetValue(22),Глубина+1);
							Организация = new V82.СправочникиСсылка.Организации((byte[])Читалка.GetValue(23),Глубина+1);
							Ответственный = new V82.СправочникиСсылка.Пользователи((byte[])Читалка.GetValue(24),Глубина+1);
							Подразделение = new V82.СправочникиСсылка.Подразделения((byte[])Читалка.GetValue(25),Глубина+1);
							ЗаписыватьДокументыТекущейДатой = ((byte[])Читалка.GetValue(26))[0]==1;
							ПроводитьДокументы = ((byte[])Читалка.GetValue(27))[0]==1;
							ПроводитьДокументыОперативно = ((byte[])Читалка.GetValue(28))[0]==1;
							СпособИдентификацииКонтрагентов = Читалка.GetString(29);
							ЕдиницаИзмеренияНовойНоменклатуры = new V82.СправочникиСсылка.КлассификаторЕдиницИзмерения((byte[])Читалка.GetValue(30),Глубина+1);
							ВыгружатьКартинки = ((byte[])Читалка.GetValue(32))[0]==1;
							Комментарий = Читалка.GetString(33);
							РегламентноеЗадание = Читалка.GetString(34);
							ИспользоватьРегламентныеЗадания = ((byte[])Читалка.GetValue(35))[0]==1;
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
		
		public V82.СправочникиОбъект.НастройкиОбменаССайтом  ПолучитьОбъект()
		{
			var Объект = new V82.СправочникиОбъект.НастройкиОбменаССайтом();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Предопределенный = Предопределенный;
			Объект.Код = Код;
			Объект.Наименование = Наименование;
			Объект.ОбменТоварами = ОбменТоварами;
			Объект.ОбменЗаказами = ОбменЗаказами;
			Объект.УзелОбменаТоварами = УзелОбменаТоварами;
			Объект.УзелОбменаЗаказами = УзелОбменаЗаказами;
			Объект.ВыгружатьТолькоИзменения = ВыгружатьТолькоИзменения;
			Объект.ВыгружатьНаСайт = ВыгружатьНаСайт;
			Объект.КаталогВыгрузки = КаталогВыгрузки;
			Объект.HTTPОбменАдресСайта = HTTPОбменАдресСайта;
			Объект.HTTPОбменИмяПользователя = HTTPОбменИмяПользователя;
			Объект.HTTPОбменПароль = HTTPОбменПароль;
			Объект.HTTPОбменПроксиИспользование = HTTPОбменПроксиИспользование;
			Объект.HTTPОбменПроксиСервер = HTTPОбменПроксиСервер;
			Объект.HTTPОбменПроксиПорт = HTTPОбменПроксиПорт;
			Объект.HTTPОбменПроксиИмяПользователя = HTTPОбменПроксиИмяПользователя;
			Объект.HTTPОбменПроксиПароль = HTTPОбменПроксиПароль;
			Объект.ГруппаДляНовыхКонтрагентов = ГруппаДляНовыхКонтрагентов;
			Объект.ГруппаДляНовойНоменклатуры = ГруппаДляНовойНоменклатуры;
			Объект.Организация = Организация;
			Объект.Ответственный = Ответственный;
			Объект.Подразделение = Подразделение;
			Объект.ЗаписыватьДокументыТекущейДатой = ЗаписыватьДокументыТекущейДатой;
			Объект.ПроводитьДокументы = ПроводитьДокументы;
			Объект.ПроводитьДокументыОперативно = ПроводитьДокументыОперативно;
			Объект.СпособИдентификацииКонтрагентов = СпособИдентификацииКонтрагентов;
			Объект.ЕдиницаИзмеренияНовойНоменклатуры = ЕдиницаИзмеренияНовойНоменклатуры;
			Объект.СохраненныеНастройкиПостроителя = СохраненныеНастройкиПостроителя;
			Объект.ВыгружатьКартинки = ВыгружатьКартинки;
			Объект.Комментарий = Комментарий;
			Объект.РегламентноеЗадание = РегламентноеЗадание;
			Объект.ИспользоватьРегламентныеЗадания = ИспользоватьРегламентныеЗадания;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.СправочникиСсылка.НастройкиОбменаССайтом ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.СправочникиСсылка.НастройкиОбменаССайтом)Кэш[УИ];
			}
			var Ссылка = new V82.СправочникиСсылка.НастройкиОбменаССайтом(УникальныйИдентификатор);
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