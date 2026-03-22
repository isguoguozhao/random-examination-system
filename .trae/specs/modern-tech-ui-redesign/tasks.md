# 单位抽考系统 - 现代科技风UI重构 - The Implementation Plan (Decomposed and Prioritized Task List)

## [ ] Task 1: 创建新的主题配色系统类
- **Priority**: P0
- **Depends On**: None
- **Description**: 
  - 创建 ModernTechTheme.cs，定义深空黑、水蓝渐变、玻璃拟态等配色
  - 实现按钮、输入框、表格、卡片的样式应用方法
  - 替代旧的 SunnyUITheme.cs
- **Acceptance Criteria Addressed**: AC-1
- **Test Requirements**:
  - `human-judgement` TR-1.1: 主题类包含所有设计方案中的颜色定义
  - `human-judgement` TR-1.2: 提供 ApplyTheme(Form) 方法用于快速应用主题
- **Notes**: 颜色值严格按照设计方案：#0F172A（深空黑）、#06B6D4→#0EA5E9（水蓝渐变）等

## [ ] Task 2: 重构登录页UI
- **Priority**: P0
- **Depends On**: Task 1
- **Description**: 
  - 完全重写 LoginForm.Designer.cs 和 LoginForm.cs
  - 深空黑背景，居中玻璃拟态登录框
  - 水蓝渐变登录按钮，精致悬停效果
  - 带图标的输入框
- **Acceptance Criteria Addressed**: AC-2, AC-6
- **Test Requirements**:
  - `human-judgement` TR-2.1: 登录页具有设计方案中的视觉效果
  - `programmatic` TR-2.2: 登录功能完全正常，无回归
- **Notes**: 保持原有的登录逻辑不变，只改UI

## [ ] Task 3: 重构主界面框架
- **Priority**: P0
- **Depends On**: Task 1
- **Description**: 
  - 重写 MainForm 布局：顶部玻璃栏 + 左侧导航侧边栏 + 主内容区
  - 导航栏：水蓝选中态，悬停效果，图标+文字
  - 顶部栏：LOGO、搜索框、用户头像
- **Acceptance Criteria Addressed**: AC-3, AC-6
- **Test Requirements**:
  - `human-judgement` TR-3.1: 主框架具有设计方案中的布局
  - `programmatic` TR-3.2: 所有导航功能正常，菜单跳转正常
- **Notes**: 保持原有的菜单逻辑不变

## [ ] Task 4: 重构单位管理页
- **Priority**: P1
- **Depends On**: Task 1, Task 3
- **Description**: 
  - 将 OrgUnitForm 改造为玻璃卡片风格
  - 树形区域和表格区域都在玻璃卡片中
  - 按钮采用新样式，表格采用新设计
- **Acceptance Criteria Addressed**: AC-4, AC-6
- **Test Requirements**:
  - `human-judgement` TR-4.1: 页面具有玻璃卡片视觉效果
  - `programmatic` TR-4.2: 所有CRUD功能正常
- **Notes**: 表格列名已中文化，保持不变

## [ ] Task 5: 重构人员管理页
- **Priority**: P1
- **Depends On**: Task 1, Task 3
- **Description**: 
  - 将 PersonForm 改造为玻璃卡片风格
  - 筛选区域、按钮、表格都采用新样式
- **Acceptance Criteria Addressed**: AC-4, AC-6
- **Test Requirements**:
  - `human-judgement` TR-5.1: 页面具有玻璃卡片视觉效果
  - `programmatic` TR-5.2: 所有功能正常（导入、搜索、CRUD）
- **Notes**: 保持Excel导入功能

## [ ] Task 6: 重构指挥组管理页
- **Priority**: P1
- **Depends On**: Task 1, Task 3
- **Description**: 
  - 将 CommandGroupForm 改造为玻璃卡片风格
  - 所有控件采用新主题样式
- **Acceptance Criteria Addressed**: AC-4, AC-6
- **Test Requirements**:
  - `human-judgement` TR-6.1: 页面具有玻璃卡片视觉效果
  - `programmatic` TR-6.2: 所有功能正常
- **Notes**: 保持复制、成员管理功能

## [ ] Task 7: 重构任务方案管理页
- **Priority**: P1
- **Depends On**: Task 1, Task 3
- **Description**: 
  - 将 TaskPlanForm 改造为玻璃卡片风格
  - 表格采用新设计（56px行高、水蓝选中态）
- **Acceptance Criteria Addressed**: AC-4, AC-6
- **Test Requirements**:
  - `human-judgement` TR-7.1: 页面具有玻璃卡片视觉效果
  - `programmatic` TR-7.2: 所有功能正常
- **Notes**: 任务方案编辑已简化为2层，保持不变

## [ ] Task 8: 重构抽考活动管理页
- **Priority**: P1
- **Depends On**: Task 1, Task 3
- **Description**: 
  - 将 ExamActivityForm 改造为玻璃卡片风格
  - 所有按钮采用新样式（查看结果、开始抽考等）
- **Acceptance Criteria Addressed**: AC-4, AC-6
- **Test Requirements**:
  - `human-judgement` TR-8.1: 页面具有玻璃卡片视觉效果
  - `programmatic` TR-8.2: 所有功能正常
- **Notes**: 保持开始抽考功能跳转

## [ ] Task 9: 重构抽考流程页
- **Priority**: P0
- **Depends On**: Task 1, Task 3
- **Description**: 
  - 优化 NewExamDrawForm 为设计方案中的4步向导
  - 添加精致的数字滚动动画
  - 水蓝渐变大按钮
  - 完成时的庆祝效果
- **Acceptance Criteria Addressed**: AC-5, AC-6
- **Test Requirements**:
  - `human-judgement` TR-9.1: 抽考流程具有设计方案中的动画和视觉
  - `programmatic` TR-9.2: 抽考逻辑完全正常，结果保存正确
- **Notes**: 这是核心体验页，重点优化动画和视觉

## [ ] Task 10: 重构结果展示页
- **Priority**: P1
- **Depends On**: Task 1, Task 9
- **Description**: 
  - 将 ExamResultForm 改造为高级数据可视化风格
  - 三个结果表格（指挥组、任务、最终）都在玻璃卡片中
  - 导出Excel、打印按钮采用新样式
- **Acceptance Criteria Addressed**: AC-4, AC-6
- **Test Requirements**:
  - `human-judgement` TR-10.1: 结果页具有高级数据可视化风格
  - `programmatic` TR-10.2: 所有功能正常（导出、打印）
- **Notes**: 保持原有的导出功能
