﻿Ext.require(['Данные.Справочники.ОстаткиОтпусков'], function () 
{
	Ext.define('Справочники.ОстаткиОтпусков.ФормаСписка',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:400px;height:300px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	resizable: false,
	title: 'Остатки отпусков прошлых лет',
	
	layout: {type: "fit",align: "stretch"},
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'СправочникСписок',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:384px;height:116px;',
			height: 116,width: 384,
			columns:
			[
				{
					text:'',
					width:'32',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Физлицо',
					width:'120',
					dataIndex:'Физлицо.Представление',
					flex:1,
				},
				{
					text:'Дата актуальности',
					width:'120',
					dataIndex:'ДатаАктуальности',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Ext.data.Store",
				{
					data: Ext.create("Данные.Справочники.ОстаткиОтпусков").data,
					fields: ['Ссылка','Картинка','Физлицо.Представление','ДатаАктуальности',]
				}).data.items,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ОстаткиОтпусков/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Картинка',
					},
					{
						name:'Физлицо',
					},
					{
						name:'ДатаАктуальности',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('СправочникСписок');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.ОстаткиОтпусков.ФормаСпискаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.ОстаткиОтпусков.ФормаСпискаСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:400px;height:25px;',
			items:
			[
				{
					xtype: 'splitbutton',
					text:'',
					menu: [
				{
					text:'Удалить',
				},
				'-',
				{
					text:'Установить отбор и сортировку списка...',
				},
				{
					text:'Отбор по значению в текущей колонке',
				},
				{
					xtype: 'splitbutton',
					text:'',
					menu: [
					]
				},
				{
					text:'Отключить отбор',
				},
				{
					xtype: 'splitbutton',
					text:'',
					menu: [
				{
					text:'(Поля сортировки)',
				},
					]
				},
				'-',
				{
					text:'Вывести список...',
				},
				{
					text:'Настройка списка...',
				},
				'-',
				{
					text:'Обновить',
				},
					]
				},
				'-',
				{
					text:'Удалить',
				},
				'-',
				{
					text:'Установить отбор и сортировку списка...',
				},
				{
					text:'Отбор по значению в текущей колонке',
				},
				{
					xtype: 'splitbutton',
					text:'',
					menu: [
				{
					text:'(Список отборов)',
				},
				'-',
				{
					text:'(История отборов)',
				},
					]
				},
				{
					text:'Отключить отбор',
				},
				'-',
				{
					text:'Обновить',
				},
				'-',
				{
					text:'Справка',
				},
			]
		},
		{
			id: 'ТабличноеПоле1',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:176px;width:384px;height:116px;',
			height: 116,width: 384,
			columns:
			[
				{
					text:'Количество',
					width:'100',
					dataIndex:'Количество',
					flex:1,
				},
				{
					text:'Дата начала рабочего года',
					width:'100',
					dataIndex:'ДатаНачалаРабочегоГода',
					flex:1,
				},
				{
					text:'Дата окончания рабочего года',
					width:'100',
					dataIndex:'ДатаОкончанияРабочегоГода',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Ext.data.Store",
				{
					data: Ext.create("Данные.Справочники.ОстаткиОтпусков").data,
					fields: ['Ссылка','Количество','ДатаНачалаРабочегоГода','ДатаОкончанияРабочегоГода',]
				}).data.items,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ОстаткиОтпусков/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Количество',
					},
					{
						name:'ДатаНачалаРабочегоГода',
					},
					{
						name:'ДатаОкончанияРабочегоГода',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ТабличноеПоле1');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.ОстаткиОтпусков.ФормаСпискаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.ОстаткиОтпусков.ФормаСпискаСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'fieldset',
			title: 'Остатки',
			style: 'position:absolute;left:8px;top:156px;width:384px;height:16px;',
		},
		],
	}],
	dockedItems:
	[
	]
	});
});