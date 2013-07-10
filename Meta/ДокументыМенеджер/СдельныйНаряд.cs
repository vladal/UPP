﻿
using System;
using System.Data.SqlClient;
using V82;
using V82.ДокументыСсылка;
using V82.Документы;//Менеджер;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.Документы//Менеджер
{
	///<summary>
	///(Общ)
	///</summary>
	public partial class СдельныйНаряд:ДокументМенеджер
	{
		
		public static ДокументыСсылка.СдельныйНаряд НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld11431RRef [Организация]
					,_Fld11432 [ОтражатьВУправленческомУчете]
					,_Fld11433 [ОтражатьВБухгалтерскомУчете]
					,_Fld11434 [ОтражатьВНалоговомУчете]
					,_Fld11435 [Комментарий]
					,_Fld11436RRef [Ответственный]
					,_Fld11437RRef [Подразделение]
					,_Fld11438_TYPE [Заказ_Тип],_Fld11438_RRRef [Заказ],_Fld11438_RTRef [Заказ_Вид]
					,_Fld11439RRef [ПодразделениеОрганизации]
					,_Fld11440 [КраткийСоставДокумента]
					,_Fld11441 [УдалитьРазвернутыйПериод]
					,_Fld22037 [УчитыватьКТУ]
					,_Fld22038 [УчитыватьТариф]
					,_Fld22039 [УчитыватьОтработанноеВремя]
					,_Fld22040 [РаспределятьТолькоПриработок]
					,_Fld22041RRef [СпособВводаДанных]
					,_Fld22042 [ПериодРегистрации]
					,_Fld22043 [ДатаНачалаПериода]
					,_Fld27316 [УчитыватьВремяТолькоПриРасчете]
					From _Document450(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СдельныйНаряд();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(14);
							Ссылка.УдалитьРазвернутыйПериод = ((byte[])Читалка.GetValue(15))[0]==1;
							Ссылка.УчитыватьКТУ = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.УчитыватьТариф = ((byte[])Читалка.GetValue(17))[0]==1;
							Ссылка.УчитыватьОтработанноеВремя = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.РаспределятьТолькоПриработок = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(21);
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(22);
							Ссылка.УчитыватьВремяТолькоПриРасчете = ((byte[])Читалка.GetValue(23))[0]==1;
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыСсылка.СдельныйНаряд НайтиПоНомеру(string Номер)
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
					,_Fld11431RRef [Организация]
					,_Fld11432 [ОтражатьВУправленческомУчете]
					,_Fld11433 [ОтражатьВБухгалтерскомУчете]
					,_Fld11434 [ОтражатьВНалоговомУчете]
					,_Fld11435 [Комментарий]
					,_Fld11436RRef [Ответственный]
					,_Fld11437RRef [Подразделение]
					,_Fld11438_TYPE [Заказ_Тип],_Fld11438_RRRef [Заказ],_Fld11438_RTRef [Заказ_Вид]
					,_Fld11439RRef [ПодразделениеОрганизации]
					,_Fld11440 [КраткийСоставДокумента]
					,_Fld11441 [УдалитьРазвернутыйПериод]
					,_Fld22037 [УчитыватьКТУ]
					,_Fld22038 [УчитыватьТариф]
					,_Fld22039 [УчитыватьОтработанноеВремя]
					,_Fld22040 [РаспределятьТолькоПриработок]
					,_Fld22041RRef [СпособВводаДанных]
					,_Fld22042 [ПериодРегистрации]
					,_Fld22043 [ДатаНачалаПериода]
					,_Fld27316 [УчитыватьВремяТолькоПриРасчете]
					From _Document450(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СдельныйНаряд();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(14);
							Ссылка.УдалитьРазвернутыйПериод = ((byte[])Читалка.GetValue(15))[0]==1;
							Ссылка.УчитыватьКТУ = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.УчитыватьТариф = ((byte[])Читалка.GetValue(17))[0]==1;
							Ссылка.УчитыватьОтработанноеВремя = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.РаспределятьТолькоПриработок = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(21);
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(22);
							Ссылка.УчитыватьВремяТолькоПриРасчете = ((byte[])Читалка.GetValue(23))[0]==1;
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыВыборка.СдельныйНаряд Выбрать()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld11431RRef [Организация]
					,_Fld11432 [ОтражатьВУправленческомУчете]
					,_Fld11433 [ОтражатьВБухгалтерскомУчете]
					,_Fld11434 [ОтражатьВНалоговомУчете]
					,_Fld11435 [Комментарий]
					,_Fld11436RRef [Ответственный]
					,_Fld11437RRef [Подразделение]
					,_Fld11438_TYPE [Заказ_Тип],_Fld11438_RRRef [Заказ],_Fld11438_RTRef [Заказ_Вид]
					,_Fld11439RRef [ПодразделениеОрганизации]
					,_Fld11440 [КраткийСоставДокумента]
					,_Fld11441 [УдалитьРазвернутыйПериод]
					,_Fld22037 [УчитыватьКТУ]
					,_Fld22038 [УчитыватьТариф]
					,_Fld22039 [УчитыватьОтработанноеВремя]
					,_Fld22040 [РаспределятьТолькоПриработок]
					,_Fld22041RRef [СпособВводаДанных]
					,_Fld22042 [ПериодРегистрации]
					,_Fld22043 [ДатаНачалаПериода]
					,_Fld27316 [УчитыватьВремяТолькоПриРасчете]
					From _Document450(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.СдельныйНаряд();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СдельныйНаряд();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(14);
							Ссылка.УдалитьРазвернутыйПериод = ((byte[])Читалка.GetValue(15))[0]==1;
							Ссылка.УчитыватьКТУ = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.УчитыватьТариф = ((byte[])Читалка.GetValue(17))[0]==1;
							Ссылка.УчитыватьОтработанноеВремя = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.РаспределятьТолькоПриработок = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(21);
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(22);
							Ссылка.УчитыватьВремяТолькоПриРасчете = ((byte[])Читалка.GetValue(23))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СдельныйНаряд ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld11431RRef [Организация]
					,_Fld11432 [ОтражатьВУправленческомУчете]
					,_Fld11433 [ОтражатьВБухгалтерскомУчете]
					,_Fld11434 [ОтражатьВНалоговомУчете]
					,_Fld11435 [Комментарий]
					,_Fld11436RRef [Ответственный]
					,_Fld11437RRef [Подразделение]
					,_Fld11438_TYPE [Заказ_Тип],_Fld11438_RRRef [Заказ],_Fld11438_RTRef [Заказ_Вид]
					,_Fld11439RRef [ПодразделениеОрганизации]
					,_Fld11440 [КраткийСоставДокумента]
					,_Fld11441 [УдалитьРазвернутыйПериод]
					,_Fld22037 [УчитыватьКТУ]
					,_Fld22038 [УчитыватьТариф]
					,_Fld22039 [УчитыватьОтработанноеВремя]
					,_Fld22040 [РаспределятьТолькоПриработок]
					,_Fld22041RRef [СпособВводаДанных]
					,_Fld22042 [ПериодРегистрации]
					,_Fld22043 [ДатаНачалаПериода]
					,_Fld27316 [УчитыватьВремяТолькоПриРасчете]
					From _Document450(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.СдельныйНаряд();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СдельныйНаряд();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(14);
							Ссылка.УдалитьРазвернутыйПериод = ((byte[])Читалка.GetValue(15))[0]==1;
							Ссылка.УчитыватьКТУ = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.УчитыватьТариф = ((byte[])Читалка.GetValue(17))[0]==1;
							Ссылка.УчитыватьОтработанноеВремя = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.РаспределятьТолькоПриработок = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(21);
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(22);
							Ссылка.УчитыватьВремяТолькоПриРасчете = ((byte[])Читалка.GetValue(23))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СдельныйНаряд ВыбратьПоНомеру(int Первые,string Мин,string Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld11431RRef [Организация]
					,_Fld11432 [ОтражатьВУправленческомУчете]
					,_Fld11433 [ОтражатьВБухгалтерскомУчете]
					,_Fld11434 [ОтражатьВНалоговомУчете]
					,_Fld11435 [Комментарий]
					,_Fld11436RRef [Ответственный]
					,_Fld11437RRef [Подразделение]
					,_Fld11438_TYPE [Заказ_Тип],_Fld11438_RRRef [Заказ],_Fld11438_RTRef [Заказ_Вид]
					,_Fld11439RRef [ПодразделениеОрганизации]
					,_Fld11440 [КраткийСоставДокумента]
					,_Fld11441 [УдалитьРазвернутыйПериод]
					,_Fld22037 [УчитыватьКТУ]
					,_Fld22038 [УчитыватьТариф]
					,_Fld22039 [УчитыватьОтработанноеВремя]
					,_Fld22040 [РаспределятьТолькоПриработок]
					,_Fld22041RRef [СпособВводаДанных]
					,_Fld22042 [ПериодРегистрации]
					,_Fld22043 [ДатаНачалаПериода]
					,_Fld27316 [УчитыватьВремяТолькоПриРасчете]
					From _Document450(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.СдельныйНаряд();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СдельныйНаряд();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(14);
							Ссылка.УдалитьРазвернутыйПериод = ((byte[])Читалка.GetValue(15))[0]==1;
							Ссылка.УчитыватьКТУ = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.УчитыватьТариф = ((byte[])Читалка.GetValue(17))[0]==1;
							Ссылка.УчитыватьОтработанноеВремя = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.РаспределятьТолькоПриработок = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(21);
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(22);
							Ссылка.УчитыватьВремяТолькоПриРасчете = ((byte[])Читалка.GetValue(23))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СдельныйНаряд СтраницаПоСсылке(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld11431RRef [Организация]
					,_Fld11432 [ОтражатьВУправленческомУчете]
					,_Fld11433 [ОтражатьВБухгалтерскомУчете]
					,_Fld11434 [ОтражатьВНалоговомУчете]
					,_Fld11435 [Комментарий]
					,_Fld11436RRef [Ответственный]
					,_Fld11437RRef [Подразделение]
					,_Fld11438_TYPE [Заказ_Тип],_Fld11438_RRRef [Заказ],_Fld11438_RTRef [Заказ_Вид]
					,_Fld11439RRef [ПодразделениеОрганизации]
					,_Fld11440 [КраткийСоставДокумента]
					,_Fld11441 [УдалитьРазвернутыйПериод]
					,_Fld22037 [УчитыватьКТУ]
					,_Fld22038 [УчитыватьТариф]
					,_Fld22039 [УчитыватьОтработанноеВремя]
					,_Fld22040 [РаспределятьТолькоПриработок]
					,_Fld22041RRef [СпособВводаДанных]
					,_Fld22042 [ПериодРегистрации]
					,_Fld22043 [ДатаНачалаПериода]
					,_Fld27316 [УчитыватьВремяТолькоПриРасчете]
					From _Document450(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.СдельныйНаряд();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СдельныйНаряд();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(14);
							Ссылка.УдалитьРазвернутыйПериод = ((byte[])Читалка.GetValue(15))[0]==1;
							Ссылка.УчитыватьКТУ = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.УчитыватьТариф = ((byte[])Читалка.GetValue(17))[0]==1;
							Ссылка.УчитыватьОтработанноеВремя = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.РаспределятьТолькоПриработок = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(21);
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(22);
							Ссылка.УчитыватьВремяТолькоПриРасчете = ((byte[])Читалка.GetValue(23))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СдельныйНаряд СтраницаПоНомеру(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld11431RRef [Организация]
					,_Fld11432 [ОтражатьВУправленческомУчете]
					,_Fld11433 [ОтражатьВБухгалтерскомУчете]
					,_Fld11434 [ОтражатьВНалоговомУчете]
					,_Fld11435 [Комментарий]
					,_Fld11436RRef [Ответственный]
					,_Fld11437RRef [Подразделение]
					,_Fld11438_TYPE [Заказ_Тип],_Fld11438_RRRef [Заказ],_Fld11438_RTRef [Заказ_Вид]
					,_Fld11439RRef [ПодразделениеОрганизации]
					,_Fld11440 [КраткийСоставДокумента]
					,_Fld11441 [УдалитьРазвернутыйПериод]
					,_Fld22037 [УчитыватьКТУ]
					,_Fld22038 [УчитыватьТариф]
					,_Fld22039 [УчитыватьОтработанноеВремя]
					,_Fld22040 [РаспределятьТолькоПриработок]
					,_Fld22041RRef [СпособВводаДанных]
					,_Fld22042 [ПериодРегистрации]
					,_Fld22043 [ДатаНачалаПериода]
					,_Fld27316 [УчитыватьВремяТолькоПриРасчете]
					From _Document450(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.СдельныйНаряд();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СдельныйНаряд();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(14);
							Ссылка.УдалитьРазвернутыйПериод = ((byte[])Читалка.GetValue(15))[0]==1;
							Ссылка.УчитыватьКТУ = ((byte[])Читалка.GetValue(16))[0]==1;
							Ссылка.УчитыватьТариф = ((byte[])Читалка.GetValue(17))[0]==1;
							Ссылка.УчитыватьОтработанноеВремя = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.РаспределятьТолькоПриработок = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(21);
							Ссылка.ДатаНачалаПериода = Читалка.GetDateTime(22);
							Ссылка.УчитыватьВремяТолькоПриРасчете = ((byte[])Читалка.GetValue(23))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.СдельныйНаряд СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.СдельныйНаряд();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.КраткийСоставДокумента = "";
			Объект.СпособВводаДанных = V82.Перечисления/*Ссылка*/.СпособыВводаДанныхОВремени.ПустаяСсылка;
			return Объект;
		}
	}
}