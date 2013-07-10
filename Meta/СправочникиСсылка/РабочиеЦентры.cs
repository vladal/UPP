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
	///<summary>
	///(Упр)
	///</summary>
	[ProtoContract]
	[DataContract]
	public partial class РабочиеЦентры:СправочникСсылка,IСериализаторProtoBuf,IСериализаторJson
	{
		public static readonly Guid ГуидКласса = new Guid("f3f2218d-044f-4591-a916-7ccaf99482e0");
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
		public bool Предопределенный {get;set;}
		public Guid Родитель {get;set;}
		public bool ЭтоГруппа {get;set;}
		public string/*9*/ Код {get;set;}
		[DataMember(Name = "Представление")]//Проверить основное представление.
		[ProtoMember(3)]
		public string/*100*/ Наименование {get;set;}
		public V82.СправочникиСсылка.Подразделения Подразделение {get;set;}
		public string/*(0)*/ Описание {get;set;}
		///<summary>
		///Признак того, что при загрузке данного рабочего центра требуется загрузка других рабочих центров и групп заменяемости рабочих центров
		///</summary>
		public bool ТребуетсяЗагрузкаПодчиненныхРабочихЦентров {get;set;}//Требуется загрузка подчиненных рабочих центров
		
		public РабочиеЦентры()
		{
		}
		
		public РабочиеЦентры(byte[] УникальныйИдентификатор)
			: this(УникальныйИдентификатор,0)
		{
		}
		
		public РабочиеЦентры(byte[] УникальныйИдентификатор,int Глубина)
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
					,_Fld1687RRef [Подразделение]
					,_Fld1688 [Описание]
					,_Fld26586 [ТребуетсяЗагрузкаПодчиненныхРабочихЦентров]
					From _Reference135(NOLOCK)
					Where _IDRRef=@УникальныйИдентификатор  and _Folder = 0x01  ";
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
							Подразделение = new V82.СправочникиСсылка.Подразделения((byte[])Читалка.GetValue(6),Глубина+1);
							Описание = Читалка.GetString(7);
							ТребуетсяЗагрузкаПодчиненныхРабочихЦентров = ((byte[])Читалка.GetValue(8))[0]==1;
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
		
		public V82.СправочникиОбъект.РабочиеЦентры  ПолучитьОбъект()
		{
			var Объект = new V82.СправочникиОбъект.РабочиеЦентры();
			Объект._ЭтоНовый = false;
			Объект.Ссылка = Ссылка;
			Объект.Версия = Версия;
			Объект.ПометкаУдаления = ПометкаУдаления;
			Объект.Предопределенный = Предопределенный;
			Объект.Родитель = Родитель;
			Объект.ЭтоГруппа = ЭтоГруппа;
			Объект.Код = Код;
			Объект.Наименование = Наименование;
			Объект.Подразделение = Подразделение;
			Объект.Описание = Описание;
			Объект.ТребуетсяЗагрузкаПодчиненныхРабочихЦентров = ТребуетсяЗагрузкаПодчиненныхРабочихЦентров;
			return Объект;
		}
		
		private static readonly Hashtable Кэш = new Hashtable(1000);
		
		public static V82.СправочникиСсылка.РабочиеЦентры ВзятьИзКэша(byte[] УникальныйИдентификатор)
		{
			var УИ = new Guid(УникальныйИдентификатор);
			if (Кэш.ContainsKey(УИ))
			{
				return (V82.СправочникиСсылка.РабочиеЦентры)Кэш[УИ];
			}
			var Ссылка = new V82.СправочникиСсылка.РабочиеЦентры(УникальныйИдентификатор);
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