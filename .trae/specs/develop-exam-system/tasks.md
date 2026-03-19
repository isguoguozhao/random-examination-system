# 开发任务列表

## 阶段一：项目基础架构搭建

- [x] Task 1: 更新项目配置
  - [x] 确认项目目标框架为.NET Framework 4.7.2（保持不变）
  - [x] 修改输出类型为Windows应用程序
  - [x] 添加SQLite依赖(System.Data.SQLite)
  - [x] 添加EPPlus依赖（Excel操作）
  - [x] 添加DocX依赖（Word操作）

- [x] Task 2: 创建项目文件夹结构
  - [x] 创建Common/Entities文件夹
  - [x] 创建Common/Utils文件夹
  - [x] 创建DAL文件夹
  - [x] 创建BLL/Services文件夹
  - [x] 创建UI/Forms文件夹
  - [x] 创建UI/Controls文件夹
  - [x] 创建UI/Utils文件夹

- [x] Task 3: 创建数据库访问层
  - [x] 创建SQLiteHelper类
  - [x] 创建数据库初始化脚本
  - [x] 实现数据库连接管理

## 阶段二：数据实体和数据库

- [x] Task 4: 创建数据实体类
  - [x] 创建SysUser实体
  - [x] 创建SysRole实体
  - [x] 创建OrgUnit实体
  - [x] 创建Person实体
  - [x] 创建CommandGroup实体
  - [x] 创建CommandGroupMember实体
  - [x] 创建TaskPlan实体
  - [x] 创建TaskPlanDetail实体
  - [x] 创建ExamActivity实体
  - [x] 创建ExamActivityGroupResult实体
  - [x] 创建ExamActivityTaskResult实体
  - [x] 创建ExamActivityFinalResult实体
  - [x] 创建ExamMustHitRule实体
  - [x] 创建SysLog实体
  - [x] 创建SysConfig实体

- [x] Task 5: 创建数据库初始化
  - [x] 编写创建所有表的SQL脚本
  - [x] 实现数据库初始化方法
  - [x] 插入默认数据（管理员账号、默认角色）

## 阶段三：业务逻辑层

- [x] Task 6: 创建用户服务
  - [x] 实现用户登录验证
  - [x] 实现用户CRUD操作
  - [x] 实现密码修改功能

- [x] Task 7: 创建单位服务
  - [x] 实现单位CRUD操作
  - [x] 实现单位树形结构查询

- [x] Task 8: 创建人员服务
  - [x] 实现人员CRUD操作
  - [x] 实现按单位筛选人员
  - [x] 实现Excel导入人员

- [x] Task 9: 创建指挥组服务
  - [x] 实现指挥组CRUD操作
  - [x] 实现指挥组成员管理
  - [x] 实现复制指挥组功能
  - [x] 实现Excel导入指挥组

- [x] Task 10: 创建任务方案服务
  - [x] 实现任务方案CRUD操作
  - [x] 实现任务明细管理
  - [x] 实现Excel导入任务方案

- [x] Task 11: 创建抽考服务
  - [x] 实现抽考活动CRUD操作
  - [x] 实现指挥组抽取算法
  - [x] 实现任务抽取算法
  - [x] 实现最终结果生成
  - [x] 实现必抽规则处理

- [x] Task 12: 创建日志服务
  - [x] 实现操作日志记录
  - [x] 实现日志查询功能

## 阶段四：用户界面层

- [x] Task 13: 创建登录界面
  - [x] 设计登录窗体UI
  - [x] 实现登录逻辑
  - [x] 实现记住账号功能

- [x] Task 14: 创建主界面
  - [x] 设计主窗体UI（菜单、工具栏、状态栏）
  - [x] 实现模块导航
  - [x] 实现用户信息显示

- [x] Task 15: 创建单位管理界面
  - [x] 设计单位管理窗体UI
  - [x] 实现单位列表展示
  - [x] 实现单位新增/编辑/删除

- [x] Task 16: 创建人员管理界面
  - [x] 设计人员管理窗体UI
  - [x] 实现人员列表展示
  - [x] 实现人员新增/编辑/删除
  - [x] 实现Excel导入功能

- [x] Task 17: 创建指挥组管理界面
  - [x] 设计指挥组管理窗体UI
  - [x] 实现指挥组列表展示
  - [x] 实现指挥组新增/编辑/删除/复制
  - [x] 实现成员管理功能
  - [x] 实现Excel导入功能

- [x] Task 18: 创建任务方案管理界面
  - [x] 设计任务方案管理窗体UI
  - [x] 实现任务方案列表展示
  - [x] 实现任务方案新增/编辑/删除
  - [x] 实现任务明细维护

- [x] Task 19: 创建抽考活动管理界面
  - [x] 设计抽考活动列表窗体UI
  - [x] 设计抽考活动创建窗体UI
  - [x] 实现活动创建和保存

- [x] Task 20: 创建三步抽考界面
  - [x] 设计第一步抽取界面（指挥组抽取）
  - [x] 实现滚动动画效果
  - [x] 实现抽取算法调用
  - [x] 设计第二步抽取界面（任务抽取）
  - [x] 设计第三步结果总览界面
  - [x] 实现三张表展示

- [x] Task 21: 创建结果导出打印界面
  - [x] 实现Excel导出功能
  - [x] 实现Word导出功能
  - [x] 实现打印功能

- [x] Task 22: 创建系统管理界面
  - [x] 设计用户管理窗体UI
  - [x] 设计必抽设置窗体UI
  - [x] 设计操作日志窗体UI

## 阶段五：功能完善和优化

- [x] Task 23: 实现权限控制
  - [x] 实现菜单权限控制
  - [x] 实现按钮权限控制
  - [x] 实现数据权限控制

- [x] Task 24: 实现数据备份恢复
  - [x] 实现数据库备份功能
  - [x] 实现数据库恢复功能

- [x] Task 25: 界面美化和优化
  - [x] 应用黄绿色调风格
  - [x] 优化表格显示
  - [x] 优化按钮和控件样式

## 阶段六：测试和部署

- [x] Task 26: 功能测试
  - [x] 测试用户登录
  - [x] 测试基础数据管理
  - [x] 测试抽考流程
  - [x] 测试导入导出

- [x] Task 27: 创建安装程序
  - [x] 创建Inno Setup安装脚本
  - [x] 打包应用程序

# 任务依赖关系

- Task 2 依赖于 Task 1
- Task 3 依赖于 Task 2
- Task 4 依赖于 Task 2
- Task 5 依赖于 Task 3 和 Task 4
- Task 6-12 依赖于 Task 4 和 Task 5
- Task 13-22 依赖于 Task 6-12
- Task 23 依赖于 Task 13-22
- Task 24 依赖于 Task 3
- Task 25 依赖于 Task 13-22
- Task 26 依赖于 Task 13-25
- Task 27 依赖于 Task 26
