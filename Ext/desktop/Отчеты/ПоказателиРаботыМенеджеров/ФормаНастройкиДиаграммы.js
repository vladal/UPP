﻿Ext.require(['Данные.Отчеты.ПоказателиРаботыМенеджеров'], function () 
{
	Ext.define('Отчеты.ПоказателиРаботыМенеджеров.ФормаНастройкиДиаграммы',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:356px;height:342px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	resizable: false,
	title: 'Настройка диаграммы (Показатели работы менеджеров)',
	
	layout: {type: "fit",align: "stretch"},
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'ПоказателиДиаграммы',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:29px;width:340px;height:280px;',
			height: 280,width: 340,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Имя показателя',
					width:'320',
					dataIndex:'Представление',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ПоказателиРаботыМенеджеров/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'Представление',
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
						var грид = Ext.getCmp('ПоказателиДиаграммы');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.ПоказателиРаботыМенеджеров.ФормаНастройкиДиаграммыСобытия'], function ()
						{
							var obj = Ext.create("Справочники.ПоказателиРаботыМенеджеров.ФормаНастройкиДиаграммыСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'fieldset',
			title: 'Показатель',
			style: 'position:absolute;left:8px;top:8px;width:340px;height:16px;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:317px;width:356px;height:25px;',
			dock: 'bottom',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'ОК',
				},
				'-',
				{
					text:'Закрыть',
					handler: function () {this.up('window').close();},
				},
			]
		},
	]
	});
});