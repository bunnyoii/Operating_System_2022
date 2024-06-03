# 请求调页存储管理方式模拟 项目文档

> 题目：请求调页存储管理方式模拟
>
> 指导教师：张慧娟
>
> 姓名：安江涛
>
> 学号：1952560

## 一、项目概述

本项目为一个内存调页模拟程序。在本项目模拟的系统中，执行的指令共有320条，一个页面可以存放10条指令，所有指令分为32页，系统中共有4个页框可供程序使用。本项目将以可视化的方式展示程序执行过程张总的换页过程，以及缺页率的统计。

## 二、功能说明

本项目实现了如下功能：

- 查看下一条指令地址
- 缺页数统计
- 缺页率统计
- 换页提示
- 指令命中提示
- 指令执行数据统计
- 单步执行指令
- 连续执行指令

![](https://github.com/AnJT/IMG/blob/main/hh_memory.png?raw=true)

总览

![](https://github.com/AnJT/IMG/blob/main/memory.png?raw=true)

## 三、项目实现

- #### 后继指令生成

  本项目50%概率顺序执行下一条指令，25%执行当前指令前的指令，25%执行当前指令后的指令，采用随机的方式执行指令，代码如下：

  ```javascript
  getNextAddress() {
    this.pre_address = this.next_address
    let rand = Math.random()
    //顺序执行
    if (rand < 0.5)
      this.next_address = (this.next_address + 1) % 320
    let dx = Math.floor(Math.random() * 160)
    //25%的概率向后跳
    if (rand < 0.75 && rand >= 0.5)
      this.next_address = (this.next_address + dx) % 320
    //25%的概率向前跳
    if (rand >= 0.75)
      this.next_address = (this.next_address - dx + 320) % 320
  }
  ```

- #### 置换算法

  本项目中实现了两个经典的页面置换算法，即先进先出置换算法（FIFO）和最近最少使用置换算法（LRU）。

  - FIFO

    > 置换最先调入内存的页面，即置换在内存中4驻留时间最久的页面。按照进入内存的先后次序排列成**队列**，从队尾进入，从队首删除。

    程序中维护了一个队列$fifo\_queue$，用于维护四个页框的换入顺序，当发生换页时，将$fifo\_queue$的首元素放到队尾，代码如下：

    ```javascript
    FIFO(){
      let frame_num = this.fifo_queue[0]
      this.fifo_queue.shift()
      this.fifo_queue.push(frame_num)
      //同时更新lru
      this.lru_queue[frame_num] = new Date().getTime()
      return [frame_num, this.frame[frame_num].num]
    }
    ```

  - LRU

    > 置换最近一段时间以来最长时间未访问过的页面。根据程序局部性原理，刚被访问的页面，可能马上又要被访问；而较长时间内没有被访问的页面，可能最近不会被访问。

    程序中维护了一个数组$lru\_queue$，用于记录每一个页面最近被使用的时刻，当发生换页时，查询该数组去除最早被使用的页面并更新该页面使用的时刻，代码如下：

    ```javascript
    LRU(){
      let frame_num = 0
      for(let i = 1; i < this.lru_queue.length; i++){
        if(this.lru_queue[i] < this.lru_queue[frame_num])
          frame_num = i
      }
      this.lru_queue[frame_num] = new Date().getTime()
      //同时更新fifo
      this.fifo_queue.splice(this.fifo_queue.indexOf(frame_num), 1)
      this.fifo_queue.push(frame_num)
      return [frame_num, this.frame[frame_num].num]
    }
    ```

### 四、项目环境

- ##### 开发环境

  Windows 10

  WebStorm

  Vue + Node.js

- ##### 运行方法

  1. 在线运行：https://anjt.github.io/Operating-system/

  2. 本地运行：

     `npm install`

     

     `npm run serve`

