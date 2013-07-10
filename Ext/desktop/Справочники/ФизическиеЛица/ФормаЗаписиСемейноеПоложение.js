﻿Ext.define('Справочники.ФизическиеЛица.ФормаЗаписиСемейноеПоложение',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:354px;height:95px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Семейное положение физ. лица',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'Надпись1',
			text: 'Запись о семейном положении действует с:',
			style: 'position:absolute;left:8px;top:43px;width:258px;height:19px;text-align:left;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'Период',
			width: 80,
			height: 19,
			style: 'position:absolute;left:266px;top:43px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись2',
			text: 'Семейное положение:',
			style: 'position:absolute;left:8px;top:8px;width:116px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			name: 'СемейноеПоложение',
			width: 220,
			height: 19,
			style: 'position:absolute;left:126px;top:8px;width:220px;height:19px;',
		},
		{
			xtype: 'fieldset',
			title: '',
			style: 'position:absolute;left:8px;top:32px;width:338px;height:6px;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:70px;width:354px;height:25px;',
			dock: 'bottom',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'История...',
				},
				'-',
				{
					text:'OK',
				},
				'-',
				{
					text:'Закрыть',
				},
			]
		},
	]
});