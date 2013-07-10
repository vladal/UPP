﻿
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.Serialization;
using ProtoBuf;/*https://github.com/ServiceStack/ServiceStack/tree/master/lib*/
using ServiceStack.Text;/*https://github.com/ServiceStack/ServiceStack.Text*/
using V82;
using V82.ОбщиеОбъекты;
using V82.СправочникиСсылка;
using V82.СправочникиОбъект;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.СправочникиОбъект
{
	///<summary>
	///(Упр)
	///</summary>
	[ProtoContract]
	[DataContract]
	public partial class СчетаБюджета:СправочникОбъект
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
		public bool Предопределенный {get;set;}
		[DataMember]
		[ProtoMember(6)]
		public Guid Владелец {get;set;}
		[DataMember]
		[ProtoMember(7)]
		public Guid Родитель {get;set;}
		[DataMember]
		[ProtoMember(8)]
		public bool ЭтоГруппа {get;set;}
		[DataMember]
		[ProtoMember(9)]
		public string/*9*/ Код {get;set;}
		[DataMember]
		[ProtoMember(10)]
		public string/*100*/ Наименование {get;set;}
		[DataMember]
		[ProtoMember(11)]
		public decimal/*(1)*/ Знак {get;set;}
		[DataMember]
		[ProtoMember(12)]
		public object СтатьяБаланса {get;set;}//Статья баланса
		public void Записать()
		{
			//Установка блокировки элемента на горизантально масштабированный кластер.
			//Опционально введение тайм аута на запись одного и того же объекта, не чаще раза в 5-секунд. Защита от спама. упращение алгоритма блокировки.
			//Выделение сервиса для блокировки элемента и генерации кода
			//Выполнение операций контроля без обращений к sql-серверу.
			//Контроль конфликта блокировок.
			//Контроль загрузки булкинсертом гетерогенной коллекции.
			//Контроль уникальности кода для справочников.
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
						Insert Into _Reference170(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_OwnerIDRRef
						,_ParentIDRRef
						,_Folder
						,_Code
						,_Description
						,_Fld2024
						,_Fld2025RRef)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Предопределенный
						,@Владелец
						,@Родитель
						,@ЭтоГруппа
						,@Код
						,@Наименование
						,@Знак
						,@СтатьяБаланса)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Reference170
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_IsMetadata	= @Предопределенный
						,_OwnerIDRRef	= @Владелец
						,_ParentIDRRef	= @Родитель
						,_Folder	= @ЭтоГруппа
						,_Code	= @Код
						,_Description	= @Наименование
						,_Fld2024	= @Знак
						,_Fld2025RRef	= @СтатьяБаланса
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Предопределенный", Предопределенный);
					Команда.Parameters.AddWithValue("Владелец", Владелец);
					Команда.Parameters.AddWithValue("Родитель", Родитель);
					Команда.Parameters.AddWithValue("ЭтоГруппа", ЭтоГруппа?new byte[]{0}:new byte[]{1});
					Команда.Parameters.AddWithValue("Код", Код);
					Команда.Parameters.AddWithValue("Наименование", Наименование);
					Команда.Parameters.AddWithValue("Знак", Знак);
					Команда.Parameters.AddWithValue("СтатьяБаланса", Guid.Empty);
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
					Команда.CommandText = @"Delete _Reference170
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
		/*МодульОбъекта*/
		// Процедура генерирует код перемещаемого элемента (группы) справочника,
		// а также код расположенного рядом элемента при интерактивном перемещении
		// элемента в форме списка справочника.
		// Записывает переставляемые элементы с измененными кодами.
		// В случае сдвига группы элементов также изменяет коды вложенных в группу
		// элементов.
		//
		// Параметры
		//  Направление  – число – направление сдвига элемента,
		//                 принимает значения:
		//                      1 - при сдвиге вниз;
		//                     -1 - при сдвиге вверх.
		//

		public void ИзменитьКод(/*Направление*/)
		{
			//ТекущийКод    = Код;
			//СписокКодов   = Новый СписокЗначений;
			//СчетаБюджета  = Справочники.СчетаБюджета;
			//ВыборкаСтроки = СчетаБюджета.Выбрать(Родитель, Владелец, , "Код Убыв");
			while(true/*ВыборкаСтроки.Следующий()*/)
			{
				//СписокКодов.Добавить(ВыборкаСтроки.Код);
			}
			if(true/*СписокКодов.Количество() < 2*/)
			{
				/*// На данном уровне имеется только один элемент или группа справочника.
*/
				/*// Игнорируем действие пользователя.
*/
			}
			//ПорядковыйНомер = СписокКодов.Индекс(СписокКодов.НайтиПоЗначению(ТекущийКод));
			if(true/*(ПорядковыйНомер = 0) И (Направление < 0)*/)
			{
				/*// Попытка перемещения первого по порядку элемента вверх.
*/
				//ИндексЭлементаЗамены = СписокКодов.Количество() - 1;
			}
			//КодЭлементаЗамены     = СписокКодов.Получить(ИндексЭлементаЗамены).Значение;
			//ЭлементЗаменыСсылка   = СчетаБюджета.НайтиПоКоду(КодЭлементаЗамены,,Родитель, Владелец);
			if(true/*ЭлементЗаменыСсылка <> СчетаБюджета.ПустаяСсылка()*/)
			{
			}
		}
		// ИзменитьКод()
	}
}