﻿Ext.define('Справочники.ДокументыУдостоверяющиеЛичность.ФормаВыбора',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:428px;height:321px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Документы, удостоверяющие личность',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'СправочникСписок',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:412px;height:280px;',
			height: 280,width: 412,
			columns:
			[
				{
					text:'',
					width:'32',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Наименование',
					width:'2200',
					dataIndex:'Наименование',
					flex:1,
				},
				{
					text:'Код ИФНС',
					width:'80',
					dataIndex:'КодИМНС',
					flex:1,
				},
				{
					text:'Код ПФР',
					width:'80',
					dataIndex:'КодПФР',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Данные.Справочники.ДокументыУдостоверяющиеЛичность").data,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ДокументыУдостоверяющиеЛичность/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Картинка',
					},
					{
						name:'Наименование',
					},
					{
						name:'КодИМНС',
					},
					{
						name:'КодПФР',
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
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:428px;height:25px;',
			items:
			[
			]
		},
		],
	}],
	dockedItems:
	[
	]
});