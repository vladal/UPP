
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
	///(Упр)
	///</summary>
	public partial class СтатьиОборотовПоБюджетам:СправочникОбъект
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
		public string/*9*/ Код;
		public string/*100*/ Наименование;
		///<summary>
		///Полное наименование, например, для печати
		///</summary>
		public string/*(0)*/ НаименованиеПолное;//Наименование полное
		///<summary>
		///Признак использования количественных оборотов
		///</summary>
		public bool УчетПоКоличеству;//Учет по количеству
		///<summary>
		///Признак использования суммовых оборотов
		///</summary>
		public bool УчетПоСумме;//Учет по сумме
		///<summary>
		///Источник данных для расчетов бюджетирования, ресурс которого будет использоваться для пересчета количественных оборотов по статье в суммовые
		///</summary>
		public V82.СправочникиСсылка.ИсточникиДанныхДляРасчетовБюджетирования ИсточникДанныхДляЦены;//Источник данных для цены
		///<summary>
		///Показатель источника данных расчетов бюджетирования, который будет использоваться для пересчета количественного оборота по статье в суммовой
		///</summary>
		public string/*(50)*/ ПоказательИсточникаДанныхДляЦены;//Показатель источника данных для цены
		public V82.СправочникиСсылка.ИсточникиДанныхДляРасчетовБюджетирования ИсточникДанныхДляФакта;//Источник данных для факта
		///<summary>
		///Показатель источника данных расчетов бюджетирования, который будет использоваться для получения фактических данных
		///</summary>
		public string/*(100)*/ ПоказательИсточникаДанныхДляФактаСум;//Показатель источника данных для факта сум
		///<summary>
		///Способ определения валюты оборота при получении фактических данных
		///</summary>
		public V82.Перечисления/*Ссылка*/.СпособыОпределенияВалютыОборотаПоСтатье СпособОпределенияВалютыОборотаФакт;//Способ определения валюты оборота факт
		///<summary>
		///Показатель источника данных расчетов бюджетирования, который будет использоваться для получения фактических данных
		///</summary>
		public string/*(100)*/ ПоказательИсточникаДанныхДляФактаКол;//Показатель источника данных для факта кол
		public V82.СправочникиСсылка.КлассификаторЕдиницИзмерения ЕдиницаИзмерения;//Единица измерения
		///<summary>
		///Признак разделения оборотов по контрагентам
		///</summary>
		public bool РазделениеПоКонтрагентам;//Разделение по контрагентам
		///<summary>
		///Признак разделения оборотов по ресурсам
		///</summary>
		public bool РазделениеПоНоменклатуре;//Разделение по номенклатуре
		public V82.СправочникиСсылка.Валюты ОсновнаяВалюта;//Основная валюта
		public V82.СправочникиСсылка.Подразделения ОсновноеЦФО;//ЦФО по умолчанию
		public V82.СправочникиСсылка.Проекты ОсновнойПроект;//Основной проект
		public V82.СправочникиСсылка.Контрагенты ОсновнойКонтрагент;//Основной контрагент
		public object ОсновнаяНоменклатура;//Основная номенклатура
		public string/*(0)*/ Комментарий;
		public decimal/*(15.2)*/ КоэффициентДляФактаСум;//Коэффициент для факта (сум)
		public decimal/*(15.2)*/ КоэффициентДляФактаКол;//Коэффициент для факта (кол)
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
						Insert Into _Reference249(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_ParentIDRRef
						,_Folder
						,_Code
						,_Description
						,_Fld3816
						,_Fld3817
						,_Fld3818
						,_Fld3819RRef
						,_Fld3820
						,_Fld3821RRef
						,_Fld3822
						,_Fld3823RRef
						,_Fld3824
						,_Fld3825RRef
						,_Fld3826
						,_Fld3827
						,_Fld3828RRef
						,_Fld3829RRef
						,_Fld3830RRef
						,_Fld3831RRef
						,_Fld3833
						,_Fld3834
						,_Fld3835)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Предопределенный
						,@Родитель
						,@ЭтоГруппа
						,@Код
						,@Наименование
						,@НаименованиеПолное
						,@УчетПоКоличеству
						,@УчетПоСумме
						,@ИсточникДанныхДляЦены
						,@ПоказательИсточникаДанныхДляЦены
						,@ИсточникДанныхДляФакта
						,@ПоказательИсточникаДанныхДляФактаСум
						,@СпособОпределенияВалютыОборотаФакт
						,@ПоказательИсточникаДанныхДляФактаКол
						,@ЕдиницаИзмерения
						,@РазделениеПоКонтрагентам
						,@РазделениеПоНоменклатуре
						,@ОсновнаяВалюта
						,@ОсновноеЦФО
						,@ОсновнойПроект
						,@ОсновнойКонтрагент
						,@Комментарий
						,@КоэффициентДляФактаСум
						,@КоэффициентДляФактаКол)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Reference249
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_IsMetadata	= @Предопределенный
						,_ParentIDRRef	= @Родитель
						,_Folder	= @ЭтоГруппа
						,_Code	= @Код
						,_Description	= @Наименование
						,_Fld3816	= @НаименованиеПолное
						,_Fld3817	= @УчетПоКоличеству
						,_Fld3818	= @УчетПоСумме
						,_Fld3819RRef	= @ИсточникДанныхДляЦены
						,_Fld3820	= @ПоказательИсточникаДанныхДляЦены
						,_Fld3821RRef	= @ИсточникДанныхДляФакта
						,_Fld3822	= @ПоказательИсточникаДанныхДляФактаСум
						,_Fld3823RRef	= @СпособОпределенияВалютыОборотаФакт
						,_Fld3824	= @ПоказательИсточникаДанныхДляФактаКол
						,_Fld3825RRef	= @ЕдиницаИзмерения
						,_Fld3826	= @РазделениеПоКонтрагентам
						,_Fld3827	= @РазделениеПоНоменклатуре
						,_Fld3828RRef	= @ОсновнаяВалюта
						,_Fld3829RRef	= @ОсновноеЦФО
						,_Fld3830RRef	= @ОсновнойПроект
						,_Fld3831RRef	= @ОсновнойКонтрагент
						,_Fld3833	= @Комментарий
						,_Fld3834	= @КоэффициентДляФактаСум
						,_Fld3835	= @КоэффициентДляФактаКол
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Предопределенный", Предопределенный);
					Команда.Parameters.AddWithValue("Родитель", Родитель);
					Команда.Parameters.AddWithValue("ЭтоГруппа", ЭтоГруппа?new byte[]{0}:new byte[]{1});
					Команда.Parameters.AddWithValue("Код", Код);
					Команда.Parameters.AddWithValue("Наименование", Наименование);
					Команда.Parameters.AddWithValue("НаименованиеПолное", НаименованиеПолное);
					Команда.Parameters.AddWithValue("УчетПоКоличеству", УчетПоКоличеству);
					Команда.Parameters.AddWithValue("УчетПоСумме", УчетПоСумме);
					Команда.Parameters.AddWithValue("ИсточникДанныхДляЦены", ИсточникДанныхДляЦены.Ссылка);
					Команда.Parameters.AddWithValue("ПоказательИсточникаДанныхДляЦены", ПоказательИсточникаДанныхДляЦены);
					Команда.Parameters.AddWithValue("ИсточникДанныхДляФакта", ИсточникДанныхДляФакта.Ссылка);
					Команда.Parameters.AddWithValue("ПоказательИсточникаДанныхДляФактаСум", ПоказательИсточникаДанныхДляФактаСум);
					Команда.Parameters.AddWithValue("СпособОпределенияВалютыОборотаФакт", СпособОпределенияВалютыОборотаФакт.Ключ());
					Команда.Parameters.AddWithValue("ПоказательИсточникаДанныхДляФактаКол", ПоказательИсточникаДанныхДляФактаКол);
					Команда.Parameters.AddWithValue("ЕдиницаИзмерения", ЕдиницаИзмерения.Ссылка);
					Команда.Parameters.AddWithValue("РазделениеПоКонтрагентам", РазделениеПоКонтрагентам);
					Команда.Parameters.AddWithValue("РазделениеПоНоменклатуре", РазделениеПоНоменклатуре);
					Команда.Parameters.AddWithValue("ОсновнаяВалюта", ОсновнаяВалюта.Ссылка);
					Команда.Parameters.AddWithValue("ОсновноеЦФО", ОсновноеЦФО.Ссылка);
					Команда.Parameters.AddWithValue("ОсновнойПроект", ОсновнойПроект.Ссылка);
					Команда.Parameters.AddWithValue("ОсновнойКонтрагент", ОсновнойКонтрагент.Ссылка);
					Команда.Parameters.AddWithValue("Комментарий", Комментарий);
					Команда.Parameters.AddWithValue("КоэффициентДляФактаСум", КоэффициентДляФактаСум);
					Команда.Parameters.AddWithValue("КоэффициентДляФактаКол", КоэффициентДляФактаКол);
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
					Команда.CommandText = @"Delete _Reference249
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
	}
}