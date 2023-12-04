function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}
ps 39069;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 39069 > /dev/null;
done;
for child in $(list_child_processes 39084);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/350fef2fb85b417d8ccf7f58f7a40b87.sh;
