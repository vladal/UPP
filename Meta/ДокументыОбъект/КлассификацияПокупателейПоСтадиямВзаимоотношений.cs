﻿
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.Serialization;
using ProtoBuf;/*https://github.com/ServiceStack/ServiceStack/tree/master/lib*/
using ServiceStack.Text;/*https://github.com/ServiceStack/ServiceStack.Text*/
using V82;
using V82.ОбщиеОбъекты;
using V82.ДокументыСсылка;
using V82.ДокументыОбъект;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.ДокументыОбъект
{
	///<summary>
	///(Упр)
	///</summary>
	[ProtoContract]
	[DataContract]
	public partial class КлассификацияПокупателейПоСтадиямВзаимоотношений:ДокументОбъект
	{
		public bool _ЭтоНовый;
		public bool ЭтоНовый()
		{
			return _ЭтоНовый;
		}
		[DataMember]
		[ProtoMember(1)]
		public Guid Ссылка {get;set;}
		[DataMember]
		[ProtoMember(2)]
		public long Версия {get;set;}
		[DataMember]
		[ProtoMember(3)]
		public string ВерсияДанных {get;set;}
		/*static хэш сумма состава и порядка реквизитов*/
		/*версия класса восстановленного из пакета*/
		[DataMember]
		[ProtoMember(4)]
		public bool ПометкаУдаления {get;set;}
		[DataMember]
		[ProtoMember(5)]
		public DateTime Дата {get;set;}
		[DataMember]
		[ProtoMember(6)]
		public DateTime ПрефиксНомера {get;set;}
		[DataMember]
		[ProtoMember(7)]
		public string/*11*/ Номер {get;set;}
		[DataMember]
		[ProtoMember(8)]
		public bool Проведен {get;set;}
		[DataMember]
		[ProtoMember(9)]
		public DateTime ДатаОкончания {get;set;}//Дата окончания
		[DataMember]
		[ProtoMember(10)]
		public V82.Перечисления/*Ссылка*/.Периодичность Периодичность {get;set;}
		[DataMember]
		[ProtoMember(11)]
		public decimal/*(3)*/ КоличествоПериодовАнализа {get;set;}//Количество периодов анализа
		[DataMember]
		[ProtoMember(12)]
		public decimal/*(10)*/ РазовыйПокупательНач {get;set;}//Разовый покупатель нач
		[DataMember]
		[ProtoMember(13)]
		public decimal/*(10)*/ РазовыйПокупательКон {get;set;}//Разовый покупатель кон
		[DataMember]
		[ProtoMember(14)]
		public decimal/*(15.2)*/ XКлассНач {get;set;}//X класс нач
		[DataMember]
		[ProtoMember(15)]
		public decimal/*(15.2)*/ XКлассКон {get;set;}//X класс кон
		[DataMember]
		[ProtoMember(16)]
		public decimal/*(15.2)*/ YКлассНач {get;set;}//Y класс нач
		[DataMember]
		[ProtoMember(17)]
		public decimal/*(15.2)*/ YКлассКон {get;set;}//Y класс кон
		[DataMember]
		[ProtoMember(18)]
		public decimal/*(15.2)*/ ZКлассНач {get;set;}//Z класс нач
		[DataMember]
		[ProtoMember(19)]
		public decimal/*(15.2)*/ ZКлассКон {get;set;}//Z класс кон
		[DataMember]
		[ProtoMember(20)]
		public string/*(0)*/ Комментарий {get;set;}
		///<summary>
		///(Общ)
		///</summary>
		[DataMember]
		[ProtoMember(21)]
		public V82.СправочникиСсылка.Пользователи Ответственный {get;set;}
		public void Записать()
		{
			//Установка блокировки элемента на горизантально масштабированный кластер.
			//Опционально введение тайм аута на запись одного и того же объекта, не чаще раза в 5-секунд. Защита от спама. упращение алгоритма блокировки.
			//Выделение сервиса для блокировки элемента и генерации кода
			//Выполнение операций контроля без обращений к sql-серверу.
			//Контроль конфликта блокировок.
			//Контроль загрузки булкинсертом гетерогенной коллекции.
			//Контроль уникальности кода для Документов.
			//Контроль уникальности номера для документов, в границах префикса.
			//Контроль владельца, он не может быть группой.
			//Контроль владельца он должен быть задан.
			//Контроль родителя он должен быть группой.
			//Контроль количества уровней, должен соотвествовать метаданным.
			//Контроль версии, объект не должен был быть записан перед чтением текущей записи, алгоритм версионника.
			//Контроль уникальности ссылки
			//Контроль зацикливания
			//Опционально контроль битых ссылок.
			//Соблюдейние транзакционности. ПередЗаписью. Открытие транзации. Валидации. ПриЗаписи. Фиксация транзакции. Информирование о записи элемента.
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					if(_ЭтоНовый)
					{
						Команда.CommandText = @"
						Insert Into _Document297(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_Number
						,_Fld5450
						,_Fld5451RRef
						,_Fld5452
						,_Fld5453
						,_Fld5454
						,_Fld5455
						,_Fld5456
						,_Fld5457
						,_Fld5458
						,_Fld5459
						,_Fld5460
						,_Fld5461
						,_Fld5462RRef)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Номер
						,@ДатаОкончания
						,@Периодичность
						,@КоличествоПериодовАнализа
						,@РазовыйПокупательНач
						,@РазовыйПокупательКон
						,@XКлассНач
						,@XКлассКон
						,@YКлассНач
						,@YКлассКон
						,@ZКлассНач
						,@ZКлассКон
						,@Комментарий
						,@Ответственный)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Document297
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_Number	= @Номер
						,_Fld5450	= @ДатаОкончания
						,_Fld5451RRef	= @Периодичность
						,_Fld5452	= @КоличествоПериодовАнализа
						,_Fld5453	= @РазовыйПокупательНач
						,_Fld5454	= @РазовыйПокупательКон
						,_Fld5455	= @XКлассНач
						,_Fld5456	= @XКлассКон
						,_Fld5457	= @YКлассНач
						,_Fld5458	= @YКлассКон
						,_Fld5459	= @ZКлассНач
						,_Fld5460	= @ZКлассКон
						,_Fld5461	= @Комментарий
						,_Fld5462RRef	= @Ответственный
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Номер", Номер);
					Команда.Parameters.AddWithValue("ДатаОкончания", ДатаОкончания);
					Команда.Parameters.AddWithValue("Периодичность", Периодичность.Ключ());
					Команда.Parameters.AddWithValue("КоличествоПериодовАнализа", КоличествоПериодовАнализа);
					Команда.Parameters.AddWithValue("РазовыйПокупательНач", РазовыйПокупательНач);
					Команда.Parameters.AddWithValue("РазовыйПокупательКон", РазовыйПокупательКон);
					Команда.Parameters.AddWithValue("XКлассНач", XКлассНач);
					Команда.Parameters.AddWithValue("XКлассКон", XКлассКон);
					Команда.Parameters.AddWithValue("YКлассНач", YКлассНач);
					Команда.Parameters.AddWithValue("YКлассКон", YКлассКон);
					Команда.Parameters.AddWithValue("ZКлассНач", ZКлассНач);
					Команда.Parameters.AddWithValue("ZКлассКон", ZКлассКон);
					Команда.Parameters.AddWithValue("Комментарий", Комментарий);
					Команда.ExecuteNonQuery();
				}
			}
		}
		public void Удалить()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Delete _Document297
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
	}
}