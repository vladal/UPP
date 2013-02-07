
using System;
using System.Data.SqlClient;
using V82;
using V82.СправочникиСсылка;
using V82.СправочникиОбъект;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.СправочникиОбъект
{
	///<summary>
	///(Регл)
	///</summary>
	public partial class СпособыОтраженияЗарплатыВРеглУчете:СправочникОбъект
	{
		public bool _ЭтоНовый;
		public bool ЭтоНовый()
		{
			return _ЭтоНовый;
		}
		public Guid Ссылка;
		public long Версия;
		/*static хэш сумма состава и порядка реквизитов*/
		/*версия класса восстановленного из пакета*/
		public bool ПометкаУдаления;
		public bool Предопределенный;
		public Guid Владелец;
		public bool ЭтоГруппа;
		public Guid Родитель;
		public string/*100*/ Наименование;
		public object СчетДт;//Счет Дт
		public object СубконтоДт1;//Субконто Дт номер 1
		public object СубконтоДт2;//Субконто Дт номер 2
		public object СубконтоДт3;//Субконто Дт номер 3
		public V82.СправочникиСсылка.СпособыРаспределенияЗатратНаВыпуск СпособРаспределенияЗатрат;//Способ распределения затрат
		public object СчетКт;//Счет Кт
		public object СубконтоКт1;//Субконто Кт номер 1
		public object СубконтоКт2;//Субконто Кт номер 2
		public object СубконтоКт3;//Субконто Кт номер 3
		public object СчетДтНУ;//Счет дебета налогового учета
		public object СубконтоДтНУ1;//Субконто Дт нал. учета номер 1
		public object СубконтоДтНУ2;//Субконто Дт нал. учета номер 2
		public object СубконтоДтНУ3;//Субконто Дт нал. учета номер 3
		public object СчетКтНУ;//Счет кредита налогового учета
		public object СубконтоКтНУ1;//Субконто Кт нал. учета номер 1
		public object СубконтоКтНУ2;//Субконто Кт нал. учета номер 2
		public object СубконтоКтНУ3;//Субконто Кт нал. учета номер 3
		public V82.Перечисления/*Ссылка*/.ОтражениеВУСН ОтражениеВУСН;//Отражение ВУСН
		public V82.СправочникиСсылка.ПодразделенияОрганизаций ПодразделениеДт;//Подразделение Дт
		public V82.СправочникиСсылка.ПодразделенияОрганизаций ПодразделениеКт;//Подразделение Кт
		public V82.Перечисления/*Ссылка*/.ВидыНачисленийОплатыТрудаПоСт255НК ВидНачисленийОплатыТрудаПоСтатье255НК;//Вид начислений оплаты труда по статье255 НК
		public void Записать()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					if(_ЭтоНовый)
					{
						Команда.CommandText = @"
						Insert Into _Reference241(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_ParentIDRRef
						,_Folder
						,_Description
						,_Fld3688RRef
						,_Fld3689RRef
						,_Fld3690RRef
						,_Fld3691RRef
						,_Fld3692RRef
						,_Fld3693RRef
						,_Fld3694RRef
						,_Fld3695RRef
						,_Fld3696RRef
						,_Fld3697RRef
						,_Fld3698RRef
						,_Fld3699RRef
						,_Fld3700RRef
						,_Fld3701RRef
						,_Fld3702RRef
						,_Fld3703RRef
						,_Fld3704RRef
						,_Fld3705RRef
						,_Fld3706RRef
						,_Fld3707RRef
						,_Fld3708RRef)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Предопределенный
						,@Родитель
						,@ЭтоГруппа
						,@Наименование
						,@СчетДт
						,@СубконтоДт1
						,@СубконтоДт2
						,@СубконтоДт3
						,@СпособРаспределенияЗатрат
						,@СчетКт
						,@СубконтоКт1
						,@СубконтоКт2
						,@СубконтоКт3
						,@СчетДтНУ
						,@СубконтоДтНУ1
						,@СубконтоДтНУ2
						,@СубконтоДтНУ3
						,@СчетКтНУ
						,@СубконтоКтНУ1
						,@СубконтоКтНУ2
						,@СубконтоКтНУ3
						,@ОтражениеВУСН
						,@ПодразделениеДт
						,@ПодразделениеКт
						,@ВидНачисленийОплатыТрудаПоСтатье255НК)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Reference241
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_IsMetadata	= @Предопределенный
						,_ParentIDRRef	= @Родитель
						,_Folder	= @ЭтоГруппа
						,_Description	= @Наименование
						,_Fld3688RRef	= @СчетДт
						,_Fld3689RRef	= @СубконтоДт1
						,_Fld3690RRef	= @СубконтоДт2
						,_Fld3691RRef	= @СубконтоДт3
						,_Fld3692RRef	= @СпособРаспределенияЗатрат
						,_Fld3693RRef	= @СчетКт
						,_Fld3694RRef	= @СубконтоКт1
						,_Fld3695RRef	= @СубконтоКт2
						,_Fld3696RRef	= @СубконтоКт3
						,_Fld3697RRef	= @СчетДтНУ
						,_Fld3698RRef	= @СубконтоДтНУ1
						,_Fld3699RRef	= @СубконтоДтНУ2
						,_Fld3700RRef	= @СубконтоДтНУ3
						,_Fld3701RRef	= @СчетКтНУ
						,_Fld3702RRef	= @СубконтоКтНУ1
						,_Fld3703RRef	= @СубконтоКтНУ2
						,_Fld3704RRef	= @СубконтоКтНУ3
						,_Fld3705RRef	= @ОтражениеВУСН
						,_Fld3706RRef	= @ПодразделениеДт
						,_Fld3707RRef	= @ПодразделениеКт
						,_Fld3708RRef	= @ВидНачисленийОплатыТрудаПоСтатье255НК
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Предопределенный", Предопределенный);
					Команда.Parameters.AddWithValue("Родитель", Родитель);
					Команда.Parameters.AddWithValue("ЭтоГруппа", ЭтоГруппа?new byte[]{0}:new byte[]{1});
					Команда.Parameters.AddWithValue("Наименование", Наименование);
					Команда.Parameters.AddWithValue("СчетДт", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоДт1", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоДт2", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоДт3", Guid.Empty);
					Команда.Parameters.AddWithValue("СпособРаспределенияЗатрат", СпособРаспределенияЗатрат.Ссылка);
					Команда.Parameters.AddWithValue("СчетКт", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоКт1", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоКт2", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоКт3", Guid.Empty);
					Команда.Parameters.AddWithValue("СчетДтНУ", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоДтНУ1", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоДтНУ2", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоДтНУ3", Guid.Empty);
					Команда.Parameters.AddWithValue("СчетКтНУ", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоКтНУ1", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоКтНУ2", Guid.Empty);
					Команда.Parameters.AddWithValue("СубконтоКтНУ3", Guid.Empty);
					Команда.Parameters.AddWithValue("ОтражениеВУСН", ОтражениеВУСН.Ключ());
					Команда.Parameters.AddWithValue("ПодразделениеДт", ПодразделениеДт.Ссылка);
					Команда.Parameters.AddWithValue("ПодразделениеКт", ПодразделениеКт.Ссылка);
					Команда.Parameters.AddWithValue("ВидНачисленийОплатыТрудаПоСтатье255НК", ВидНачисленийОплатыТрудаПоСтатье255НК.Ключ());
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
					Команда.CommandText = @"Delete _Reference241
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
		/*МодульОбъекта*/

		public void УстановитьТипыСубконто(/*Счет, ДтКт*/)
		{
			//ВидыСубконтоСчета = Счет.ВидыСубконто;
		}

		public void ПередЗаписью(/*Отказ*/)
		{
			if(true/*Не ЭтоГруппа*/)
			{
				//УстановитьТипыСубконто(СчетДт,   "Дт");
				//УстановитьТипыСубконто(СчетДтНУ, "ДтНУ");
				//УстановитьТипыСубконто(СчетКт,   "Кт");
				//УстановитьТипыСубконто(СчетКтНУ, "КтНУ");
			}
		}
	}
}